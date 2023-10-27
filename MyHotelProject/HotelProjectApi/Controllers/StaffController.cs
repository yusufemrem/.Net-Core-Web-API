using FluentValidation.Results;
using MHBusinessLayer.Abstract;
using MHBusinessLayer.ValidationRules;
using MHDtoLayer.StaffDto;
using MHEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet("{id}")]
        public IActionResult GetStaf(int id)
        {
            var values = _staffService.TGetByID(id);
            return Ok(values);
        }
        [HttpGet("getListStaff")]
        public IActionResult getListStaff()
        {
            var values = _staffService.TGetList();
            return Ok(values);
        }
        [HttpPost("AddStaff")]
        public IActionResult AddStaff(StaffDto staffDto)
        {
            CreateStaffValidation csv = new CreateStaffValidation();
            ValidationResult result = csv.Validate(staffDto);

            if(result.IsValid)
            {
                var staff = new Staff
                {
                    StaffID = staffDto.StaffID,
                    Name = staffDto.Name,
                    Title = staffDto.Title,
                    SocialMedia1 = staffDto.SocialMedia1
                };
                _staffService.TInsert(staff);
                return Ok();
            }

            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage); 
                }
            }
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            var values = _staffService.TGetByID(id);
            _staffService.TDelete(values);
            return Ok();
        }
    }
}
