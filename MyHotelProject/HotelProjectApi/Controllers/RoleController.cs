using HotelProjectApi.Models;
using MHEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return Ok(values);
        }
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(AddRoleViewModel addRoleViewModel)
        {
            AppRole appRole = new AppRole()
            {
                Name = addRoleViewModel.Name
            };
            var result = await _roleManager.CreateAsync(appRole);

            return Ok(result);

        }

        [HttpGet("AssignRole")]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
         //   string userid = user.Id.ToString();
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
            foreach (var item in roles)
            {
                RoleAssignViewModel model = new RoleAssignViewModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Exist = userRoles.Contains(item.Name);
                roleAssignViewModels.Add(model);
            }
            return Ok(roleAssignViewModels);
        }
    }
}
