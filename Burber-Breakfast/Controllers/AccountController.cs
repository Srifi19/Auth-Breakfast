using BuberBreakfast.Contracts.Account;
using BuberBreakfast.Contracts.Breakfast;
using BurberBreakfast.Models;
using BurberBreakfast.ServiceError;
using BurberBreakfast.Services.AccountServices;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BurberBreakfast.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAccount([FromBody] RegisterRequest model)
        {
            ErrorOr<Created> registerAccountResult = await _accountService.CreateAccount(model);
            if (registerAccountResult.IsError)
            {
                return BadRequest();
            }
            else{
                var isAdmin = await _accountService.IsInRoleAsync(model.Username, "Admin");
                var res = new LoginResponse(
                        model.Username,
                        model.Password,
                        !isAdmin.IsError,
                        true
                    );
                return Ok(res);
            }

        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            Console.WriteLine("POtrrr");
            ErrorOr<Success> loginAccountResult = await _accountService.Login(model);
            if (loginAccountResult.IsError)
            {
                return Unauthorized();
            }
            else
            {
                var isAdmin = await _accountService.IsInRoleAsync(model.username, "Admin");
                var res = new LoginResponse(
                        model.username,
                        model.password,
                        isAdmin.Value,
                        true
                    );
                return Ok(res);
            }
        }
    
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var result = _accountService.GetAllAccounts();
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogOut();
            return Ok("User logged out successfully.");
        }



    }
}
