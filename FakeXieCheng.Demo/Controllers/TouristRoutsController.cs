using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeXieCheng.Demo.AutoMapper;
using FakeXieCheng.Demo.DTOS;
using FakeXieCheng.Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FakeXieCheng.Demo.Models;
using FakeXieCheng.Demo.RequestParams;
using Microsoft.AspNetCore.JsonPatch;
using FakeXieCheng.Demo.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using System.Dynamic;
using Microsoft.Extensions.Configuration;

namespace FakeXieCheng.Demo.Controllers
{
    [Route("api/touristRouts")]
    [ApiController]

    public class TouristRoutsController : ControllerBase
    {
        public ITouristRoutRepository TouristRoutRepo { get; }
        private readonly IUrlHelper urlHelper;
        private readonly IMapper _autoMapper;
        private readonly IPropertyMappingServer propertyMappingServer;
        private readonly string localConfigMedia;

        public TouristRoutsController(
            ITouristRoutRepository touristRout,
            IMapper mapper,
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionContextAccessor,
            IPropertyMappingServer propertyMappingServer,
            IConfiguration configuration
            )
        {
            this.TouristRoutRepo = touristRout;
            this._autoMapper = mapper;
            //URLhellper 注入
            this.urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);

            this.propertyMappingServer = propertyMappingServer;
            this.localConfigMedia = configuration["CostomApplicationType:hateoas"].Trim().ToLowerInvariant();
        }

       private string CreateTousitRouteUrl(
            TouristRouteRequestParam param,
            PagingRequestParam pagingRequestParam,
            ResourceUrlEnum urlEnum
            )
        {
            string url = string.Empty;
            switch (urlEnum)
            {
                case ResourceUrlEnum.PreviousPage:
                    url = urlHelper.Link("GetTousistRoutsAsync", new
                    {
                        fields = param.Fields,
                        orderBy = pagingRequestParam.OrderBy,
                        keyWord = param.TitleKeyWord,
                        rating = param.Rating,
                        pageNumber = pagingRequestParam.PageNumber - 1,
                        pageSize = pagingRequestParam.PageSize,
                    });
                    break;
                case ResourceUrlEnum.NextPage:
                    url = urlHelper.Link("GetTousistRoutsAsync", new
                    {
                        fields = param.Fields,
                        orderBy = pagingRequestParam.OrderBy,
                        keyWord = param.TitleKeyWord,
                        rating = param.Rating,
                        pageNumber = pagingRequestParam.PageNumber + 1,
                        pageSize = pagingRequestParam.PageSize,
                    });
                    break;
                case ResourceUrlEnum.CurrentPage:
                    url = urlHelper.Link("GetTousistRoutsAsync", new
                    {
                        fields = param.Fields,
                        orderBy = pagingRequestParam.OrderBy,
                        keyWord = param.TitleKeyWord,
                        rating = param.Rating,
                        pageNumber = pagingRequestParam.PageNumber,
                        pageSize = pagingRequestParam.PageSize,
                    });
                    break;
                default:
                    break;
            }
            return url;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpHead]
        [HttpGet(Name = "GetTousistRoutsAsync")]
        public async Task<IActionResult> GetTousistRoutsAsync(
            [FromQuery] TouristRouteRequestParam param,
            [FromQuery] PagingRequestParam pagingRequestParam,
            [FromHeader(Name ="Accept")] string mediaTypeStr 
            )
        {
            if (!propertyMappingServer.ExistPropertys<TouristRoutDTO, TouristRout>(pagingRequestParam.OrderBy))
            {
                return BadRequest("排序参数设置错误！");
            }
            if (!propertyMappingServer.ExistShapeFields<TouristRoutDTO>(param.Fields))
            {
                return BadRequest($"指定字段查询参数错误：{param.Fields}");
            }
            var data = await TouristRoutRepo.GetTourisRoutsAsync(param, pagingRequestParam);
            if (data == null || data.Count() <= 0)
            {
                return NotFound("没有找到旅游路线列表");
            }
            else
            {
                var previousPageLink = data.HasPrevious ? CreateTousitRouteUrl(param, pagingRequestParam, ResourceUrlEnum.PreviousPage) : null;
                var nextPageLink = data.HasNextPage ? CreateTousitRouteUrl(param, pagingRequestParam, ResourceUrlEnum.NextPage) : null;
                //添加自定义分页导航信息（返回的头部信息）
                Response.Headers.Add("x-pagination", JsonConvert.SerializeObject(new
                {
                    previousPageLink,
                    nextPageLink,
                    totalCount = data.TotalCount,
                    pageSize = data.PageSize,
                    pageNumber = data.CurrentPageNu,
                    totalPages = data.TotalPage,
                }));
                var dataDto = _autoMapper.Map<IEnumerable<TouristRoutDTO>>(data);
                var shapeDataDtoList = dataDto.ShapeData(param.Fields);
                if (this.localConfigMedia==mediaTypeStr.Trim().ToLowerInvariant())
                {
                    var touristLinks = CreateLinkDtosForGetTourisRouts(param, pagingRequestParam);
                    //函数式写法
                    int idx = 0;
                    var shapeDataDtoListToList = shapeDataDtoList.ToList();
                    var shapeDataDtoLinqList = dataDto.Select(xt =>
                    {
                        var toursitDic = shapeDataDtoListToList[idx] as IDictionary<string, object>;
                        var links = CreateTouristRouteLinks(xt.ID, null);
                        toursitDic.Add("links", links);
                        idx++;
                        return toursitDic;
                    });
                    var result = new
                    {
                        value = shapeDataDtoLinqList,
                        links = touristLinks,
                    };
                    return Ok(result);
                }
                return Ok(shapeDataDtoList);
            }
        }

        private IEnumerable<LinkDto> CreateTouristRouteLinks(Guid routeId, string fields)
        {
            List<LinkDto> links = new List<LinkDto>();
            //自己
            links.Add(new LinkDto(
                Url.Link("GetTourisRout", new { routeId, fields }),
                "self",
                "Get"
                ));

            //增加
            links.Add(new LinkDto(
                Url.Link("CreateTouristRouteAsync", null),
                "Create",
                "Post"
                ));

            //更新
            links.Add(new LinkDto(
                    Url.Link("UpdateRoteAsync", new { routeId }),
                    "Updata",
                    "Put"
                ));

            //局部更新
            links.Add(new LinkDto(
                    Url.Link("PartialUpdateRouteAsync", new { routeId }),
                    "PartialUpdata",
                    "Patch"
                ));

            //删除
            links.Add(new LinkDto(
                     Url.Link("DeleteRouteAsync", new { routeId }),
                    "DeleteRoute",
                    "Delete"
                ));

            //获取图片链接信息
            links.Add(new LinkDto(
                    Url.Link("GetTouristRoutetPicturesAsync", new { touristRoutsID=routeId }),
                    "GetPicturs",
                    "Get"
                ));
            //创建图片链接
            links.Add(new LinkDto(
                    Url.Link("CreateTouristRoutePictureAsync", new { touristRoutsID=routeId }),
                    "CreatePicture",
                    "Post"
                ));

            return links;

        }

        //为多个类创建Linkdto资源
        private IEnumerable<LinkDto> CreateLinkDtosForGetTourisRouts(
              TouristRouteRequestParam param,
             PagingRequestParam pagingRequestParam
            )
        {
            List<LinkDto> touristLinkDtos = new List<LinkDto>();

            touristLinkDtos.Add(new LinkDto(
                    CreateTousitRouteUrl(param, pagingRequestParam, ResourceUrlEnum.CurrentPage),
                    "self",
                    "Get"
                ));

            //创建旅游资源链接
            touristLinkDtos.Add(new LinkDto(
                    Url.Link("CreateTouristRouteAsync", null),
                    "Create_touristRoute",
                    "Post"
                ));

            return touristLinkDtos;
        }

        [HttpGet("{routeId}", Name = "GetTourisRout")]
        [HttpHead("{routeId}")]
        public async Task<IActionResult> GetTourisRoutAsync([FromRoute] Guid routeId, [FromQuery] string fields)
        {
            var touristRoutFromRepository = await TouristRoutRepo.GetTouristRoutAsync(routeId);
            if (touristRoutFromRepository == null)
            {
                return NotFound($"旅游路线{routeId}不存在");
            }
            else
            {
                var touristRoutDTO = _autoMapper.Map<TouristRoutDTO>(touristRoutFromRepository);

                //创建连接信息
                var links = CreateTouristRouteLinks(routeId, fields);
                var shapeData = touristRoutDTO.ShapeData<TouristRoutDTO>(fields);
                ((IDictionary<string, object>)shapeData).Add("links", links);

                return Ok(shapeData);
            }
        }

        //[Authorize(AuthenticationSchemes ="Bearer")]
        //[Authorize(Roles ="admin")]
        [HttpPost(Name = "CreateTouristRouteAsync")]
        public async Task<IActionResult> CreateTouristRouteAsync([FromBody] TouristRouteCreateDto touristRouteCreateDto)
        {
            TouristRout touristRoutData = _autoMapper.Map<TouristRout>(touristRouteCreateDto);
            if (touristRoutData == null)
            {
                return BadRequest();
            }
            TouristRoutRepo.AddTouristRoute(touristRoutData);
            if (await TouristRoutRepo.SaveAsync())
            {
                var links = CreateTouristRouteLinks(touristRoutData.ID, null);
                var dataDato = _autoMapper.Map<TouristRoutDTO>(touristRoutData);
                var shapeDataDtoDic = dataDato.ShapeData<TouristRoutDTO>(null) as IDictionary<string, object>;
                shapeDataDtoDic.Add("links", links);
                return CreatedAtRoute("GetTousistRoutsAsync", new { routeId = touristRoutData.ID }, shapeDataDtoDic);
            }
            else
            {
                return BadRequest();
            }
        }


        [Authorize(Roles = "admin", AuthenticationSchemes = "Bearer")]
        [HttpPut("{routeId}", Name = "UpdateRoteAsync")]
        public async Task<IActionResult> UpdateRoteAsync([FromRoute] Guid routeID, [FromBody] TouristRouteUpdateDto routeUpdateDto)
        {
            if (!await TouristRoutRepo.JudgeTouristRouteExistAsync(routeID))
            {
                return NotFound($"没有找到旅游路线{routeID}");
            }
            if (routeUpdateDto == null)
            {
                return BadRequest();
            }
            TouristRout touristRouteFromRepo = await TouristRoutRepo.GetTouristRoutAsync(routeID);
            // 这个操作完成了吧 updateDTO 到 查询出来的数据更新
            _autoMapper.Map(routeUpdateDto, touristRouteFromRepo);

            return await GetSaveOperationResultAsync();
        }

        [HttpPatch("{routeId}", Name = "PartialUpdateRouteAsync")]
        [Authorize(Roles = "admin", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> PartialUpdateRouteAsync([FromRoute] Guid routeId, [FromBody] JsonPatchDocument<TouristRouteUpdateDto> partialRouteDto)
        {
            if (!await TouristRoutRepo.JudgeTouristRouteExistAsync(routeId))
            {
                return NotFound($"没有找到旅游路线{routeId}");
            }
            TouristRout originalRouteFromRepo = await TouristRoutRepo.GetTouristRoutAsync(routeId);
            TouristRouteUpdateDto orgTransFromUpdataDto = _autoMapper.Map<TouristRouteUpdateDto>(originalRouteFromRepo);

            //数据补丁添加到dto中 再把打完补丁dto添加到原始数据上，因为只有原始数据才被变化追踪的
            partialRouteDto.ApplyTo(orgTransFromUpdataDto, ModelState);
            //添加数据校验
            if (!TryValidateModel(orgTransFromUpdataDto))
            {
                return ValidationProblem(ModelState);
            }
            _autoMapper.Map(orgTransFromUpdataDto, originalRouteFromRepo);
            return await GetSaveOperationResultAsync();
        }

        [HttpDelete("{routeID}", Name = "DeleteRouteAsync")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
        public async Task<IActionResult> DeleteRouteAsync([FromRoute] Guid routeID)
        {
            var routeDel = await TouristRoutRepo.GetTouristRoutAsync(routeID);
            if (routeDel == null)
            {
                return NotFound($"要删除的，旅游路线{routeID}不存在");
            }
            TouristRoutRepo.DeleteTouristRoute(routeDel);

            return await GetSaveOperationResultAsync();
        }

        private async Task<IActionResult> GetSaveOperationResultAsync()
        {
            bool saveFlag = await TouristRoutRepo.SaveAsync();
            if (saveFlag)
            {
                return NoContent(); //根据实际项目需求返回 目前返回：204
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
        [HttpDelete("({ids})")]
        public async Task<IActionResult> DeleteRoutesAsync([ModelBinder(BinderType = typeof(ArrayModelBinder))][FromRoute] IEnumerable<Guid> ids)
        {
            if (ids == null || ids.Count() <= 0)
            {
                return BadRequest();
            }
            IEnumerable<TouristRout> routeDelList = await TouristRoutRepo.GetTourisRoutsAsync(ids);
            if (routeDelList == null || routeDelList.Count() <= 0)
            {
                return NotFound($"批量删除旅游路线不存在");
            }
            TouristRoutRepo.DeleteTouristRoutes(routeDelList);
            return await GetSaveOperationResultAsync();
        }
    }
}
