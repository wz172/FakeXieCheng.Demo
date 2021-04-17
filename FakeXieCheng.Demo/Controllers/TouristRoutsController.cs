﻿using System;
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

namespace FakeXieCheng.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutsController : ControllerBase
    {
        public ITouristRoutRepository TouristRout { get; }

        private readonly IMapper _autoMapper;
        public TouristRoutsController(ITouristRoutRepository touristRout, IMapper mapper)
        {
            this.TouristRout = touristRout;
            this._autoMapper = mapper;
        }
        [HttpHead]
        [HttpGet]
        public IActionResult GetTousistRouts([FromQuery] TouristRouteRequestParam param)
        {
            var data = TouristRout.GetTourisRouts(param);
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



        [HttpGet("{id}")]
        [HttpHead("{id}")]
        public IActionResult GetTourisRout(Guid id)
        {
            var touristRoutFromRepository = TouristRout.GetTouristRout(id);
            if (touristRoutFromRepository == null)
            {
                return NotFound($"旅游路线{id}不存在");
            }
            else
            {
                var touristRoutDTO = _autoMapper.Map<TouristRoutDTO>(touristRoutFromRepository);
                return Ok(touristRoutDTO);
            }
        }
    }
}
