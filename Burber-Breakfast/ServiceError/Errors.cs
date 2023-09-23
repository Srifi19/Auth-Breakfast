using ErrorOr;

namespace BurberBreakfast.ServiceError
{
    public static class Errors
    {
        public static class BreakfastError
        {
            public static Error NotFound => Error.NotFound(
                    code:"BreakFast.NotFound",
                    description:"Breakfast Not Found"
                );
        }
        public static class AccountError
        {
            public static Error NotFound => Error.NotFound(
                    code: "Account.NotFound",
                    description: "Account Not Found"
                );
            public static Error NotCreated => Error.Failure(
                   code: "Account.NotCreated",
                   description: "Account Not Created"
               );
            public static Error NotDeleted => Error.Failure(
                   code: "Account.NotDeleted",
                   description: "Account Not Deleted"
               );
        }
    }
   
}
