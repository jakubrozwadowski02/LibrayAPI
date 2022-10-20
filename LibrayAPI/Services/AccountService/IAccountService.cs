using LibrayAPI.Dtos.User;

namespace LibrayAPI.Services.AccountService
{
    public interface IAccountService
    {
        Task RegisterUser(RegisterUserDto registerUserDto);
        Task<string> GenerateJwt(LoginUserDto loginUserDto);
    }
}
