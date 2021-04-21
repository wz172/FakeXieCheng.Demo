using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeXieCheng.Demo.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using FakeXieCheng.Demo.Models;

namespace FakeXieCheng.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration configration;
        private readonly UserManager<MyApplicationIdentity> userManager;
        private readonly SignInManager<MyApplicationIdentity> signInManager;

        public UserController(IConfiguration configration, UserManager<MyApplicationIdentity> userManager, SignInManager<MyApplicationIdentity> signInManager)
        {
            this.configration = configration;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginPostAsync([FromBody] LogInDto logInfo)
        {
            //1.验证用户名和密码

            var isVaildFlag = await signInManager.PasswordSignInAsync(logInfo.Email, logInfo.Password, false, false);
            if (!isVaildFlag.Succeeded)
            {
                return BadRequest();
            }
            var user = await userManager.FindByEmailAsync(logInfo.Email);
            //2.生成JWT
            //2.1 确定头部加密算法
            var head = SecurityAlgorithms.HmacSha256;
            //2.2 要加密数据
            var dataClaims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id)
            };
            var roleNames = await userManager.GetRolesAsync(user);
            foreach (string roleName in roleNames)
            {
                dataClaims.Add(new Claim(ClaimTypes.Role, roleName));
            }
            //2.3 数字签名部分
            var configkeyBytes = Encoding.UTF8.GetBytes(configration["SignatureKey:loginKey"]);
            var signingKey = new SymmetricSecurityKey(configkeyBytes);
            var mysigningCreadentials = new SigningCredentials(signingKey, head);

            //public JwtSecurityToken(string issuer = null, string audience = null, IEnumerable<Claim> claims = null, DateTime? notBefore = null, DateTime? expires = null, SigningCredentials signingCredentials = null)
            var token = new JwtSecurityToken(
                    issuer: configration["SignatureKey:Issuer"],
                    audience: configration["SignatureKey:Audience"],
                     dataClaims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddDays(int.Parse(configration["SignatureKey:ExpiresDays"])),
                    mysigningCreadentials
                );
            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            //3. 返回数据
            return Ok(tokenStr);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterPostAsync([FromBody] RegisterUserDto userInfo)
        {
            if (userInfo == null)
            {
                return BadRequest();
            }
            MyApplicationIdentity user = new MyApplicationIdentity() { Email = userInfo.Email, UserName = userInfo.Email };
            //使用userManger 对密码进行加密 和保存数据 先注入对象
            var result = await userManager.CreateAsync(user, userInfo.Password);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
