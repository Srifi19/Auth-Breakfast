using BuberBreakfast.Contracts.Breakfast;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services.IServices
{
    public interface IBreakfastService
    {
        Task<ResponseDto?> GetBreakfastAsync(Guid id);
        Task<ResponseDto?> AddBreakfastAsync(BreakfastRequest breakfast);
        Task<ResponseDto?> DeleteBreakfastAsync(Guid id);
        Task<ResponseDto?> EditBreakfastAsync(Guid id, BreakfastRequest breakfast);
        Task<ResponseDto?> GetAllBreakfastAsync();
    }
}
