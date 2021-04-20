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

namespace FakeXieCheng.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutsController : ControllerBase
    {
        public ITouristRoutRepository TouristRoutRepo { get; }

        private readonly IMapper _autoMapper;
        public TouristRoutsController(ITouristRoutRepository touristRout, IMapper mapper)
        {
            this.TouristRoutRepo = touristRout;
            this._autoMapper = mapper;
        }
        [HttpHead]
        [HttpGet]
        public async Task<IActionResult> GetTousistRoutsAsync([FromQuery] TouristRouteRequestParam param)
        {
            var data = await TouristRoutRepo.GetTourisRoutsAsync(param);
            if (data == null || data.Count() <= 0)
            {
                return NotFound("没有找到旅游路线列表");
            }
            else
            {
                var dataDto = _autoMapper.Map<IEnumerable<TouristRoutDTO>>(data);
                return Ok(dataDto);
            }
        }



        [HttpGet("{routeId}", Name = "GetTourisRout")]
        [HttpHead("{routeId}")]
        public async Task<IActionResult> GetTourisRoutAsync(Guid routeId)
        {
            var touristRoutFromRepository = await TouristRoutRepo.GetTouristRoutAsync(routeId);
            if (touristRoutFromRepository == null)
            {
                return NotFound($"旅游路线{routeId}不存在");
            }
            else
            {
                var touristRoutDTO = _autoMapper.Map<TouristRoutDTO>(touristRoutFromRepository);
                return Ok(touristRoutDTO);
            }
        }

        [Authorize]
        [HttpPost]
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
                return CreatedAtRoute("GetTourisRout", new { routeId = touristRoutData.ID }, _autoMapper.Map<TouristRoutDTO>(touristRoutData));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{routeId}")]
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

        [HttpPatch("{routeId}")]
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

        [HttpDelete("{routeID}")]
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
