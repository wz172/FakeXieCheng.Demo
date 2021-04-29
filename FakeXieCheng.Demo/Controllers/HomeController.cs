using FakeXieCheng.Demo.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet(Name = "GetRootLinks")]
        [AllowAnonymous]
        public IActionResult GetRootLinks()
        {
            return Ok(GetMainLinks());
        }

        private List<LinkDto> GetMainLinks()
        {
            List<LinkDto> ls = new List<LinkDto>();
            //自我连接
            ls.Add(new LinkDto(
                Url.Link("GetRootLinks", null),
                "self",
                "Get"
                ));
            //获取旅游资源链接
            ls.Add(new LinkDto(
                Url.Link("GetTousistRoutsAsync",null),
                "GetTouristRoutes",
                "Get"
                ));
            //创建一条旅游资源
            ls.Add(new LinkDto(
                Url.Link("CreateTouristRouteAsync", null),
                "CrateToursitRoute",
                "Post"
                ));
            //获取购物车
            ls.Add(new LinkDto(
                    Url.Link("GetShoppingByUserIdAsync", null),
                    "GetShoppingCart",
                    "Get"
                ));
            //获取订单信息
            ls.Add(new LinkDto(
                    Url.Link("GetFakeXiechenOrders", null),
                    "GetOrdersInfo",
                    "Get"
                ));
            return ls;
        }
    }
}
