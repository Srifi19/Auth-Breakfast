using BurberBreakfast.Models;
using ErrorOr;

namespace BurberBreakfast.Services.BreakfastServices
{
    public interface IBreakfastService
    {
        ErrorOr<Created> CreateBreakfast(Breakfast breakfast);
        ErrorOr<Breakfast> GetBreakfast(Guid id);
        ErrorOr<Deleted> DeleteBreakfast(Guid id);
        ErrorOr<UpsertedBreakfast> UpdateBreakfast(Breakfast breakfast);

        ErrorOr<IEnumerable<Breakfast>> GetAllBreakfasts();
    }
}
