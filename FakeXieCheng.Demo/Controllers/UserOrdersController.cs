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
    public class UserOrdersController : ControllerBase
    {
        private readonly ITouristRoutRepository routeRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;
        public UserOrdersController(
            ITouristRoutRepository routeRepository,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper
            )
        {
            this.routeRepository = routeRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
        }
        // GET: api/<UserOrdersController>
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetOrders()
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var orders = await routeRepository.GetUserOrdersByUidAsync(userId);
            if (orders == null)
            {
                return NotFound($"用户{userId}的订单信息不存在");
            }
            return Ok(mapper.Map<IEnumerable<UserOrderDto>>(orders));
        }

        // GET api/<UserOrdersController>/5
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetOrderDetailsByid([FromRoute] Guid id)
        {
            //var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var order = await routeRepository.GetUserOrderDetailsByIdAsync(id);
            if (order == null)
            {
                return NotFound($"订单信息{id}不存在");
            }
            return Ok(mapper.Map<UserOrderDto>(order));
        }

        // POST api/<UserOrdersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserOrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserOrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
