using WebApplication1.Models.DTOs;

namespace WebApplication1.Services.IServices
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);

    }
}
