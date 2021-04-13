using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeXieCheng.Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeXieCheng.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutsController : ControllerBase
    {
        public ITouristRoutRepository TouristRout { get; }
        public TouristRoutsController(ITouristRoutRepository touristRout)
        {
            this.TouristRout = touristRout;
        }
        [HttpGet]
        public IActionResult GetTousistRouts()
        {
            var data = TouristRout.GetTourisRouts();
            return Ok(data);
        }
    }
}
