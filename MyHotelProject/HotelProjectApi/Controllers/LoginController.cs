using MHDtoLayer.LoginDto;
using MHEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        [HttpPost("Index")]
        public async Task<IActionResult> Index(LoginUserDto loginUserDto)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginUserDto.Username, loginUserDto.Password, false, false);
                if (result.Succeeded)
                {


                    var user = await _userManager.FindByNameAsync(loginUserDto.Username);
                    HttpContext.Session.SetString("UserName", user.UserName);

                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }


            return Ok();

        }

        [HttpGet("getUserInfo")]
        public async Task<IActionResult> getUserInfo()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            if (!string.IsNullOrEmpty(UserName))
            {
                return Ok(UserName);
            }
            else
            {
                return BadRequest("Kullanıcı oturumu bulunamadı.");
            }
            return Ok();
        }
        //[HttpPost("LogOut")]
        //public async Task<IActionResult> LogOut(LoginUserDto loginUserDto)
        //{
        //     var userId = HttpContext.Session.GetString("UserId");

        //    if (!string.IsNullOrEmpty(userId))
        //    {

        //        // Kullanıcının kimlik bilgileri varsa, oturumu sonlandırın
        //        await _signInManager.SignOutAsync();

        //        // Kullanıcının kimlik bilgilerini temizleyin
        //        HttpContext.Session.Remove("userId");

        //        return Ok(new { message = "Başarılı bir şekilde oturum sonlandırıldı." });
        //    }

        //    return BadRequest(new { message = "Oturum başlatılmamış veya kullanıcı kimlik bilgileri bulunamadı." });
        //}
    }
}
