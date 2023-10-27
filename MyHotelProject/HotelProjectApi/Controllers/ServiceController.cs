using MHBusinessLayer.Abstract;
using MHBusinessLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        //[HttpGet("getServiceList")]
        //public IActionResult getServiceList()
        //{
        //  var values =  _serviceService.TGetList();
        //    return Ok(values);
        //}
        [HttpGet("{id}")]
        public IActionResult getGetById(int id)
        {
          var values =  _serviceService.TGetByID(id);
            return Ok(values);
        }
    }
}
