using WebApplication1.Models.DTOs;
using WebApplication1.Services.IServices;
using WebApplication1.Utility;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseService _baseService;
        public UserService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequestDto,
                Url = SD.APIBase + "/Account/Login"
            });
        }

        public async Task<ResponseDto?> RegisterAsync(RegisterationRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationRequestDto,
                Url = SD.APIBase + "/Account/Register"
            });
        }

        public async Task<ResponseDto?> GetAllUsers()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.APIBase + "/Account/GetAllUsers"
            });
        }
    }
}
