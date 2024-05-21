using BusBookink.Bl;

namespace BusBookink.Services
{
    public interface IAuthService
    {
        string GenerateToken(LoginModel loginModel);

        Task<bool> Login(LoginModel loginModel);
        
        Task<bool> Register(RegisterModel registerModel);
    }
}
