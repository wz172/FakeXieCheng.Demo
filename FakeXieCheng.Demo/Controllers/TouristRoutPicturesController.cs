using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FakeXieCheng.Demo.Services;
using FakeXieCheng.Demo.Models;
using FakeXieCheng.Demo.DTOS;
using FakeXieCheng.Demo.Util;


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
                return NotFound($"没有找到ID{id}的图片");
            }
            return Ok(_mapper.Map<TouristRoutPictureDto>(picture));
        }


        //[HttpPost]
        //public IActionResult Post([FromBody] string acceptStr)
        //{
        //    return Ok("这是一个图片的POST请求方法"+ acceptStr);
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
        public IActionResult DeletePicture([FromRoute]Guid touristRoutsID, [FromRoute]int id)
        {
            if (!_fakerepository.JudgeTouristRouteExist(touristRoutsID))
            {
                return NotFound($"旅游路线{touristRoutsID}不存在");
            }
            TouristRoutPicture pictureDel = _fakerepository.GetTouistRoutePicture(touristRoutsID, id);
            if (pictureDel==null)
            {
                return NotFound($"没有找到ID{id}的图片");
            }
            _fakerepository.DeleteTouristRoutePicture(pictureDel);
            if (_fakerepository.Save())
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{ids}")]
        public IActionResult DeletePicture([FromRoute]Guid touristRoutsID, [ModelBinder(BinderType =typeof(ArrayModelBinder))] [FromRoute]IEnumerable<int> ids)
        {
            if (!_fakerepository.JudgeTouristRouteExist(touristRoutsID))
            {
                return NotFound($"旅游路线{touristRoutsID}不存在");
            }
            var picturesDelList = _fakerepository.GetTouristRoutesPictures(touristRoutsID, ids);
            if (picturesDelList==null||picturesDelList.Count()<=0)
            {
                return NotFound($"要删除旅游路线{touristRoutsID}的图片信息不存在");
            }
            _fakerepository.DeleteTouristRoutePictures(picturesDelList);
            if (_fakerepository.Save())
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
