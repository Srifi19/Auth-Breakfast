using BuberBreakfast.Contracts.Breakfast;
using BurberBreakfast.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Services.IServices;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class BreakfastController : Controller
    {
        private readonly IBreakfastService _breakfastService;

        public BreakfastController(IBreakfastService breakfestService)
        {
            _breakfastService = breakfestService;

        }


        [HttpGet]
        public async Task<IActionResult> GetAllBreakfast()
        {
            var response = await _breakfastService.GetAllBreakfastAsync();
            if (response?.IsSuccess == true)
            {
                var breakfasts = JsonConvert.DeserializeObject<ICollection<Breakfast>>(response.Result.ToString());
                return Json(breakfasts);
            }

            // Handle failure or empty response
            return View("GetEveryBreakfast");
        }

        [HttpGet]
        public IActionResult GetEveryBreakfast()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetBreakfast(Guid id)
        {
            var result = await _breakfastService.GetBreakfastAsync(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult CreateBreakfast()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBreakfast(BreakfastRequest breakfast)
        {
            var result = await _breakfastService.AddBreakfastAsync(breakfast);
            return View(result);

        }

        [HttpGet]
        public async Task<IActionResult> DeleteBreakfast(Guid id)
        {
            var result = await _breakfastService.DeleteBreakfastAsync(id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> EditBreakfast(Guid id)
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> EditBreakfast(Breakfast breakfast)
        {
            BreakfastRequest breakfast1 = new BreakfastRequest(breakfast.Name, breakfast.Description, breakfast.StartDateTime, breakfast.EndDateTime);
            var result = await _breakfastService.EditBreakfastAsync(breakfast.Id, breakfast1);
            return View(result);
        }
    }
}
