using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FakeXieCheng.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutPicturesController : ControllerBase
    {
        private readonly IMapper _mapper;

        public TouristRoutPicturesController(IMapper mapper)
        {
            this._mapper = mapper;
        }

        // GET: api/<TouristRoutPicturesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TouristRoutPicturesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TouristRoutPicturesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TouristRoutPicturesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TouristRoutPicturesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
