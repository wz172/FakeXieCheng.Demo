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
        public IActionResult GetTousistRouts([FromQuery] TouristRouteRequestParam param)
        {
            var data = TouristRoutRepo.GetTourisRouts(param);
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
        public IActionResult GetTourisRout(Guid routeId)
        {
            var touristRoutFromRepository = TouristRoutRepo.GetTouristRout(routeId);
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

        [HttpPost]
        public IActionResult CreateTouristRoute([FromBody] TouristRouteCreateDto touristRouteCreateDto)
        {
            TouristRout touristRoutData = _autoMapper.Map<TouristRout>(touristRouteCreateDto);
            if (touristRoutData == null)
            {
                return BadRequest();
            }
            TouristRoutRepo.AddTouristRoute(touristRoutData);
            if (TouristRoutRepo.Save())
            {
                return CreatedAtRoute("GetTourisRout", new { routeId = touristRoutData.ID }, _autoMapper.Map<TouristRoutDTO>(touristRoutData));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{routeId}")]
        public IActionResult UpdateRote([FromRoute] Guid routeID,[FromBody] TouristRouteUpdateDto routeUpdateDto)
        {
            if (!TouristRoutRepo.JudgeTouristRouteExist(routeID))
            {
                return NotFound($"没有找到旅游路线{routeID}");
            }
            if (routeUpdateDto==null)
            {
                return BadRequest();
            }
            TouristRout touristRouteFromRepo = TouristRoutRepo.GetTouristRout(routeID);
            // 这个操作完成了吧 updateDTO 到 查询出来的数据更新
            _autoMapper.Map(routeUpdateDto, touristRouteFromRepo);
            bool saveFlag = TouristRoutRepo.Save();
            if (saveFlag)
            {
                return NoContent(); //根据实际项目需求返回 目前返回：204
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPatch("{routeId}")]
        public IActionResult PartialUpdateRoute([FromRoute] Guid routeId,[FromBody] JsonPatchDocument<TouristRouteUpdateDto> partialRouteDto)
        {
            if (!TouristRoutRepo.JudgeTouristRouteExist(routeId))
            {
                return NotFound($"没有找到旅游路线{routeId}");
            }
            TouristRout originalRouteFromRepo = TouristRoutRepo.GetTouristRout(routeId);
            TouristRouteUpdateDto orgTransFromUpdataDto = _autoMapper.Map<TouristRouteUpdateDto>(originalRouteFromRepo);

            //数据补丁添加到dto中 再把打完补丁dto添加到原始数据上，因为只有原始数据才被变化追踪的
            partialRouteDto.ApplyTo(orgTransFromUpdataDto);
            //添加数据校验
            //TryValidateModel()

            _autoMapper.Map(orgTransFromUpdataDto, originalRouteFromRepo);
            bool saveFlag = TouristRoutRepo.Save();
            if (saveFlag)
            {
                return NoContent(); //根据实际项目需求返回 目前返回：204
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
