using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using WebApplication1.Models.DTOs;
using WebApplication1.Services.IServices;


namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor httpContextAccessor;
        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Request.Cookies.ContainsKey("YourAuthCookieName"))
            {
                // User is already logged in, redirect them to a different page
                return RedirectToAction("GetAllBreakfest", "Breakfest"); // Modify the action and controller names accordingly
            }
            else
            {
                // User is not logged in, redirect them to the login page
                return View(); // Modify the action and controller names accordingly
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto obj)
        {

            if (ModelState.IsValid && obj != null)
            {

                var responseDto = await _userService.LoginAsync(obj);

                if (responseDto != null && responseDto.IsSuccess)
                {
                    var loginResponseDto =
                        JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto?.Result) ?? "");

                    if (loginResponseDto == null) return View(obj);
                    await SignInUser(loginResponseDto);
                    return RedirectToAction("GetAllBreakfest", "Breakfest");
                }
                else
                {
                    TempData["error"] = responseDto?.Message ?? "Wrong Password";
                    return View(obj);
                }
            }
            return View(obj);



        }


        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterationRequestDto obj)
        {

            await Logout();
            var result = await _userService.RegisterAsync(obj);


            if (result != null && result.IsSuccess)
            {

                TempData["success"] = "Registration Successful";
                LoginRequestDto login = new LoginRequestDto()
                {
                    UserName = obj.Username,
                    Password = obj.Password
                };

                return RedirectToAction("Login");

            }
            else
            {
                TempData["error"] = result?.Message ?? "It didnt work";
            }



            return View(obj);
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var adminClaim = claimsIdentity.FindFirst(ClaimTypes.Role);
                if (adminClaim != null && adminClaim.Value == "Admin")
                {
                    claimsIdentity.RemoveClaim(adminClaim);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]

        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _userService.GetAllUsers();
            if (response?.IsSuccess == true && response.Result != null)
            {
                var users = JsonConvert.DeserializeObject<ICollection<UserDto>>(response.Result.ToString());
                return Json(users);
            }

            // Handle failure or empty response
            return View();
        }

        public IActionResult GetUsers()
        {
            return View();
        }


        private async Task SignInUser(LoginResponseDto model)
        {

            var claims = new List<Claim>();

            if (!string.IsNullOrEmpty(model.UserId))
            {
                claims.Add(new Claim(ClaimTypes.NameIdentifier, model.UserId));
            }

            if (!string.IsNullOrEmpty(model.UserName))
            {
                claims.Add(new Claim(ClaimTypes.Name, model.UserName));
            }
            if (model.isAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddHours(10), // Set the expiration time as needed
                IsPersistent = true, // Set to true if you want persistent cookies
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

        }

    }
}



