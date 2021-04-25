using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FakeXieCheng.Demo.DTOS;
using FakeXieCheng.Demo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FakeXieCheng.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {

        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ITouristRoutRepository repository;
        private readonly IMapper mapper;

        public ShoppingCartsController(
            IHttpContextAccessor contextAccessor,
            ITouristRoutRepository routeRepository,
             IMapper mapper)
        {
            this.httpContextAccessor = contextAccessor;
            this.repository = routeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetShoppingByUserIdAsync()
        {
            //1.获取用户ID
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //2. 获取用户购物车
            var shoppingCart = await repository.GetShoopingCartByUserIdAsync(userId);
            //3. 返回Dto
            return Ok(mapper.Map<ShoppingCartDto>(shoppingCart));
        }

        // GET api/<ShoppingCartsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ShoppingCartsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ShoppingCartsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShoppingCartsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
