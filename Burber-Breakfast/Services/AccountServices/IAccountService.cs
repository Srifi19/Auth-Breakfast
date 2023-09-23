using BuberBreakfast.Contracts.Account;
using BurberBreakfast.Models;
using BurberBreakfast.Services.BreakfastServices;
using ErrorOr;

namespace BurberBreakfast.Services.AccountServices
{
    public interface IAccountService
    {
        Task<ErrorOr<Created>> CreateAccount(RegisterRequest request);
        Task<ErrorOr<ApplicationUser>> GetAccount(String id);
        Task<ErrorOr<Success>> Login(LoginRequest request);
        Task<ErrorOr<Deleted>> DeleteAccount(String id);
        IEnumerable<ApplicationUser> GetAllAccounts();
        Task<ErrorOr<Success>> LogOut();
        Task<ErrorOr<Boolean>> IsInRoleAsync(String username, String role);
    }
}
