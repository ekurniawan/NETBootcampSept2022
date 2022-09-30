using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBackendApp.DAL;
using MyBackendApp.DTO;

namespace MyBackendApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _user;
        public UsersController(IUser user)
        {
            _user = user;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Registration(AddUserDto userDto)
        {
            try
            {
                await _user.Registration(userDto);
                return Ok($"Registrasi User {userDto.Username} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
