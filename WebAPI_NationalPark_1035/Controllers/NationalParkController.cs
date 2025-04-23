
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI_NationalPark_1035.Models.DTOs;
using WebAPI_NationalPark_1035.Models;
using WebAPI_NationalPark_1035.Repository.IRepository;

namespace WebAPI_NationalPark_1035.Controllers
{
    [Route("api/nationalPark")]
    [ApiController]

    public class NationalParkController : Controller
    {
        private readonly INationalParkRepository _nationalParkRepository;
        private readonly IMapper _mapper;
        public NationalParkController(INationalParkRepository nationalParkRepository, IMapper mapper)
        {
            _mapper = mapper;
            _nationalParkRepository = nationalParkRepository;
        }

        [HttpGet]
        public IActionResult GetNationalParks()
        {
            var nationalParkListDto = _nationalParkRepository.GetNationalParks().
                ToList().Select(_mapper.Map<NationalPark, NationalParkDto>);
            return Ok(nationalParkListDto);//200
        }
        [HttpGet("{nationalParkId:int}",Name = "GetNationalPark")]
        public IActionResult GetNationalPark(int nationalParkId)
        {
            var nationalPark = _nationalParkRepository.GetNationalPark(nationalParkId);
            if (nationalPark == null) return NotFound();
            var nationalParkDto = _mapper.Map<NationalParkDto>(nationalPark);
            return Ok(nationalParkDto); //200
        }
        [HttpPost]
        public IActionResult CreateNationalPark([FromBody] NationalParkDto nationalParkDto)
        {
            if (nationalParkDto == null) return BadRequest(ModelState);//400
            if (_nationalParkRepository.NationalParkExists(nationalParkDto.Name))
            {
                ModelState.AddModelError("", "National Park In DB !!!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            if (!ModelState.IsValid) return BadRequest(ModelState); //400
            var nationalPark = _mapper.Map<NationalParkDto, NationalPark>(nationalParkDto);
            if (!_nationalParkRepository.CreateNatioanlPark(nationalPark))
            {
                ModelState.AddModelError
                    ("", $"Somethimg went wrong while create NP:{nationalPark.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            // return Ok();//200

            return CreatedAtRoute("GetNationalPark",
                 new { nationalParkId = nationalPark.Id }, nationalPark);//201
        }
       
       //update
      [HttpPut]
      public IActionResult UpdateNationalPark
     ([FromBody] NationalParkDto nationalParkDto)
      {
          if (nationalParkDto == null) return BadRequest(ModelState);
          if (!ModelState.IsValid) return BadRequest();
          var nationalPark = _mapper.Map<NationalPark>(nationalParkDto);
          if (!_nationalParkRepository.UpdateNationalPark(nationalPark))
          {
              ModelState.AddModelError
                  ("", $"Something went wrong while update NP: {nationalPark.Name}");
              return StatusCode(StatusCodes.Status500InternalServerError);
          }
          return NoContent(); //202
      }
         [HttpDelete("{nationalParkId:int}")]
         public IActionResult DeleteNationalPark(int nationalParkId)
         {
             if (!_nationalParkRepository.NationalParkExists(nationalParkId))
                 return NotFound();
             var nationalPark = _nationalParkRepository.GetNationalPark(nationalParkId);
             if (nationalPark == null) return NotFound();
             if (!_nationalParkRepository.DeleteNationalPark(nationalPark))
             {
                 ModelState.AddModelError
                     ("", $"Something went wrong while delete NP:{nationalPark.Name} ");
                 return StatusCode(StatusCodes.Status500InternalServerError);
             }
             return Ok();
         }

    }
}

  