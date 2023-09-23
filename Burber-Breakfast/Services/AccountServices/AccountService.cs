using BuberBreakfast.Contracts.Account;
using BurberBreakfast.Models;
using BurberBreakfast.ServiceError;
using ErrorOr;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Azure.Core;

namespace BurberBreakfast.Services.AccountServices
{
    public class AccountService : IAccountService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager; 
        }

        public async Task<ErrorOr<Created>> CreateAccount(RegisterRequest request)
        {
            if(request == null)
            {
                return Errors.AccountError.NotCreated;
            }
            var newUser = new ApplicationUser
            {
                UserName = request.Username, // Set the username
                Email = request.Email // Set the email address
                // Set other user properties if needed
            };
           
            var response = await _userManager.CreateAsync(newUser, request.Password);
            Console.WriteLine(response.Errors);
            if (response.Succeeded)
            {
                if (request.isAdmin)
                {
                    
                    if (!await _roleManager.RoleExistsAsync("Admin"))
                    {
                        var role = new IdentityRole("Admin");
                        await _roleManager.CreateAsync(role);
                    }
                    
                    await _userManager.AddToRoleAsync(newUser, "Admin");
                }
                        
                return Result.Created;
            }
            else
            {
                return Errors.AccountError.NotCreated;
            }


        }

        public async Task<ErrorOr<Deleted>> DeleteAccount(String id)
        {
            if (id == null)
            {
                return Errors.AccountError.NotFound;
            }
            var response =  await _userManager.DeleteAsync(await _userManager.FindByIdAsync(id));
            if (response.Succeeded)
            {
                return Result.Deleted;
            }
            else
            {
                return Errors.AccountError.NotDeleted;
            }
        }

        public async Task<ErrorOr<ApplicationUser>> GetAccount(string id)
        {
            if(id == null)
            {
                return Errors.AccountError.NotFound;
            }

            var result = await _userManager.FindByIdAsync(id);
            if (result == null)
            {
                return Errors.AccountError.NotFound;
            }
            return result;
        }

        public IEnumerable<ApplicationUser> GetAllAccounts()
        {
            return _userManager.Users.ToList();
        }

        public async Task<ErrorOr<Success>> Login(LoginRequest request)
        {
            Console.WriteLine("Guess WHat");
            if(request == null)
            {
                return Errors.AccountError.NotFound;
            }
            
            var result = await _signInManager.PasswordSignInAsync(request.username, request.password, false, false);
            
            if (result.Succeeded)
            {
                

                return Result.Success;
                
                
            }
            else
            {
                return Errors.AccountError.NotFound;
            }
        }

        public async Task<ErrorOr<Success>> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Result.Success;
        }

   
        public async Task<ErrorOr<Boolean>> IsInRoleAsync(String username , String role)
        {
            var user = await _userManager.FindByNameAsync(username);
            var isInAdminRole = await _userManager.IsInRoleAsync(user, role);
            return isInAdminRole;
            

            
        }
    }
}
