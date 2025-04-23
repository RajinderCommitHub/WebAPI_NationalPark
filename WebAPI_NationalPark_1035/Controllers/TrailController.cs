using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_NationalPark_1035.Models.DTOs;
using WebAPI_NationalPark_1035.Repository.IRepository;

namespace WebAPI_NationalPark_1035.Controllers
{
    [Route("api/trail")]
    [ApiController]
    public class TrailController : Controller
    {
        private readonly ITrailRepository _trailRepository;
        private readonly IMapper _mapper;
    }
          
}
