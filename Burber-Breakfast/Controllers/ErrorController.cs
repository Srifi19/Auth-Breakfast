using Microsoft.AspNetCore.Mvc;

namespace BurberBreakfast.Controllers
{
   
    public class ErrorController : ControllerBase
    {
        [Route("/Error")]
        [HttpGet]
        public IActionResult Error()
        {
            return Problem();
        }
    }
}
