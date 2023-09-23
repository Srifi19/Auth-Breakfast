using WebApplication1.Models.DTOs;

namespace WebApplication1.Services.IServices
{
    public interface IUserService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> RegisterAsync(RegisterationRequestDto registrationRequestDto);
        Task<ResponseDto?> GetAllUsers();
    }
}
