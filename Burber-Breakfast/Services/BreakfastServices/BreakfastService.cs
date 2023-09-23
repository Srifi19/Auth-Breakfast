using BurberBreakfast.Data;
using BurberBreakfast.Models;
using BurberBreakfast.ServiceError;
using ErrorOr;

namespace BurberBreakfast.Services.BreakfastServices
{
    public class BreakfastService : IBreakfastService
    {

        private readonly AppDbContext db;
        public BreakfastService(AppDbContext db)
        {
            this.db = db;
        }
        public ErrorOr<Created> CreateBreakfast(Breakfast breakfast)
        {
            db.Breakfasts.Add(breakfast);
            Console.WriteLine("Updated");
            db.SaveChanges();
            return Result.Created;
        }

        public ErrorOr<Deleted> DeleteBreakfast(Guid id)
        {
            var breakfast = db.Breakfasts.Find(id);
            if (breakfast != null)
            {
                db.Breakfasts.Remove(breakfast);
                db.SaveChanges();

                return Result.Deleted;
            }
            return Errors.BreakfastError.NotFound;
        }

        public ErrorOr<IEnumerable<Breakfast>> GetAllBreakfasts()
        {           
            var _allbreakfasts = db.Breakfasts.ToList();
            return _allbreakfasts;
        }

        public ErrorOr<Breakfast> GetBreakfast(Guid id)
        {
            var breakfast = db.Breakfasts.Find(id);
            if (breakfast != null)
            {
                return breakfast;
            }

            return Errors.BreakfastError.NotFound;
        }

        public ErrorOr<UpsertedBreakfast> UpdateBreakfast(Breakfast breakfast)
        {
            var existingBreakfast = db.Breakfasts.Find(breakfast.Id);
            if (existingBreakfast != null)
            {
                db.Entry(existingBreakfast).CurrentValues.SetValues(breakfast);
                db.SaveChanges();
            }
            else
            {
                db.Breakfasts.Add(breakfast);
                db.SaveChanges();
            }

            var isNewlyCreated = existingBreakfast == null;
            return new UpsertedBreakfast(isNewlyCreated);
        }
    }
}
