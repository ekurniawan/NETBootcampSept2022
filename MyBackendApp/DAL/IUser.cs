using MyBackendApp.DTO;

namespace MyBackendApp.DAL
{
    public interface IUser
    {
        Task Registration(AddUserDto user);
        Task<IEnumerable<UserGetDto>> GetAll();
        Task<UserGetDto> Authenticate(AddUserDto user);
    }
}
