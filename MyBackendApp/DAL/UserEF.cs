using Microsoft.AspNetCore.Identity;
using MyBackendApp.DTO;
using System.Text;

namespace MyBackendApp.DAL
{
    public class UserEF : IUser
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserEF(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<UserGetDto> Authenticate(AddUserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserGetDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Registration(AddUserDto user)
        {
            try
            {
                var newUser = new IdentityUser
                {
                    UserName = user.Username,
                    Email = user.Username
                };
                var result = await _userManager.CreateAsync(newUser,user.Password);
                if(!result.Succeeded)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach(var error in result.Errors)
                    {
                        sb.Append($"{error.Code} - {error.Description} \n");
                    }
                    throw new Exception(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
