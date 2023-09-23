using BuberBreakfast.Contracts.Breakfast;
using WebApplication1.Models.DTOs;
using WebApplication1.Services.IServices;
using WebApplication1.Utility;

namespace WebApplication1.Services
{
    public class BreakfastService : IBreakfastService
    {

        private readonly IBaseService _baseService;

        public BreakfastService(IBaseService baseService)
        {
            _baseService = baseService;
        }


        public async Task<ResponseDto?> AddBreakfastAsync(BreakfastRequest breakfast)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = breakfast,
                Url = SD.APIBase + "/Breakfast/CreateBreakfast"
            });
        }

        public async Task<ResponseDto?> DeleteBreakfastAsync(Guid id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.APIBase + "/Breakfast/DeleteBreakfast/" + id
            }); ;
        }

        public async Task<ResponseDto?> EditBreakfastAsync(Guid id, BreakfastRequest breakfast)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.PUT,
                Data = breakfast,
                Url = SD.APIBase + "/Breakfast/UpsertBreakfast/" + id
            });
        }

        public async Task<ResponseDto?> GetAllBreakfastAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.APIBase + "/Breakfast/GetAllBreakfasts"
            }); ;
        }

        public async Task<ResponseDto?> GetBreakfastAsync(Guid id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.APIBase + "/Breakfast/GetBreakfast/" + id
            }); ;
        }
    }
}
