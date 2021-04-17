using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FakeXieCheng.Demo.Services;
using FakeXieCheng.Demo.Models;
using FakeXieCheng.Demo.DTOS;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FakeXieCheng.Demo.Controllers
{
    [Route("api/touristRouts/{touristRoutsID}/Pictures")]
    [ApiController]
    public class TouristRoutPicturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITouristRoutRepository _fakerepository;

        public TouristRoutPicturesController(IMapper mapper, ITouristRoutRepository fakerepository)
        {
            this._mapper = mapper;
            this._fakerepository = fakerepository;
        }

        // GET: api/<TouristRoutPicturesController>
        [HttpGet,HttpHead]
        public IActionResult Get(Guid touristRoutsID)
        {
            if (!_fakerepository.JudgeTouristRouteExist(touristRoutsID))
            {
                return NotFound($"旅游路线{touristRoutsID}不存在");
            }
            IEnumerable<TouristRoutPicture> picturesFromRepo = _fakerepository.GetTouristRoutesPictures(touristRoutsID);
            if (picturesFromRepo == null || picturesFromRepo.Count() <= 0)
            {
                return NotFound($"没有找到关于{touristRoutsID}图片");
            }
            return Ok(_mapper.Map <IEnumerable<TouristRoutPictureDto>>(picturesFromRepo));
        }

        // GET api/<TouristRoutPicturesController>/5
        [HttpGet("{id}",Name ="GetPictureByID"),HttpHead("{id}")]
        public IActionResult Get(Guid touristRoutsID,int id)
        {
            TouristRoutPicture picture = _fakerepository.GetTouistRoutePicture(touristRoutsID, id);
            if (picture==null)
            {
                return NotFound($"没有找打ID{id}的图片");
            }
            return Ok(_mapper.Map<TouristRoutPictureDto>(picture));
        }


        //[HttpPost]
        //public IActionResult Post([FromBody] string value)
        //{
        //    return Ok("这是一个图片的POST请求方法"+value );
        //}

        [HttpPost]
        public IActionResult Post([FromRoute]Guid touristRoutsID, [FromBody]TouristRoutePicturesCreateDto pictureCreateDto)
        {
            TouristRoutPicture pictureData = _mapper.Map<TouristRoutPicture>(pictureCreateDto);
            try
            {
                _fakerepository.AddTouristRoutePicture(touristRoutsID, pictureData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
                return BadRequest();
            }
            if (_fakerepository.Save())
            {
                return CreatedAtRoute("GetPictureByID", new { id = pictureData.ID , touristRoutsID =pictureData.TouristRoutID}, _mapper.Map<TouristRoutPictureDto>( pictureData));
            }
            else
            {
                return BadRequest();
            }
           
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
