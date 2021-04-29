using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FakeXieCheng.Demo.DTOS;
using FakeXieCheng.Demo.Models;
using FakeXieCheng.Demo.Services;
using FakeXieCheng.Demo.Util;
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

        [HttpGet(Name = "GetShoppingByUserIdAsync")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetShoppingByUserIdAsync()
        {
            //1.获取用户ID
            var userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //2. 获取用户购物车
            var shoppingCart = await repository.GetShoopingCartByUserIdAsync(userId);
            //3. 返回Dto
            return Ok(mapper.Map<ShoppingCartDto>(shoppingCart));
        }

        // GET api/<ShoppingCartsController>/5
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes ="Bearer")]
        public string GetOrderBy(int id)
        {
            return "value";
        }

        // POST api/<ShoppingCartsController>
        [HttpPost("items")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> CreateShoppingCartItems([FromBody] ShoppingCartCreateDto touristRoute)
        {
            //1. 先获取用户登录ID信息
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //2.(判断用户是否存,这个jwt框架帮你做过了)  获取用户购物车
            var shoppingCart = await repository.GetShoopingCartByUserIdAsync(userId);
            if (shoppingCart == null)
            {
                return NotFound($"用户{userId}的购物车不存在");
            }
            //3.获取旅游路线信息
            var tourist = await repository.GetTouristRoutAsync(touristRoute.TouristRouteID);
            if (tourist == null)
            {
                return NotFound($"旅游线路{touristRoute.TouristRouteID}不存在");
            }

            CartLineItem lineItems = new CartLineItem()
            {
                OriginalPrice = tourist.OriginalPrice,
                DiscountPresent = tourist.DiscountPresent,
                ShoppingCartId = shoppingCart.Id,
                TouristID = tourist.ID,
                TouristRout = tourist,
            };
            //5. 异步调用上下文添加
            await repository.AddCartLineItemAsync(lineItems);
            //6.保存
            await repository.SaveAsync();
            //7. 返回
            return Ok(mapper.Map<ShoppingCartDto>(shoppingCart));
        }

        // PUT api/<ShoppingCartsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShoppingCartsController>/5
        [HttpDelete("items/{cartLineId}")]
        public async Task<IActionResult> DeleteOneCartLineItemAsync([FromRoute] int cartLineId)
        {
            var cartLine = await repository.GetCartLineItemByIDAsync(cartLineId);
            if (cartLine == null)
            {
                return NotFound($"要删除{cartLineId}商品信息不存在。");
            }
            repository.DeleteLineItem(cartLine);
            await repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("items/({cartLineIds})")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteCartLineItems([ModelBinder(BinderType = typeof(ArrayModelBinder))][FromRoute] IEnumerable<int> cartLineIds)
        {
            var lineItems = await repository.GetCartLineItemByIDsAsync(cartLineIds);
            if (lineItems == null)
            {
                return NotFound("批量删除的订单信息不存在");
            }
            repository.DeleteLineItems(lineItems);
            await repository.SaveAsync();
            return NoContent();
        }
        [HttpPost("checkout")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> CreateOrderCheckout()
        {
            //1. 获取当前用户ID
            var uid = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //2. 获取用户购物车
            var userShopping = await repository.GetShoopingCartByUserIdAsync(uid);
            if (userShopping == null)
            {
                return NotFound($"用户{uid}的购物车不存在");
            }
            else if (userShopping.ShoppingCartItems == null)
            {
                return NotFound($"用户{uid}的购物车没有商品");
            }
            //3.创建订单
            var userOrder = new UserOrder()
            {
                Id = Guid.NewGuid(),
                UserID = uid,
                UserOrderCartItems = userShopping.ShoppingCartItems,
                CreateTimeUtc = DateTime.UtcNow,
                OrderState = OrderStateEnum.Generateing,
                ThirdPartyPayMent = "阿里巴巴",
            };
            userShopping.ShoppingCartItems = null;
           await repository.AddOrderAsync(userOrder);
            await repository.SaveAsync();
            return Ok(mapper.Map<UserOrderDto>(userOrder));
        }
    }
}
