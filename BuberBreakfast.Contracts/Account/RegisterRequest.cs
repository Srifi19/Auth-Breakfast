using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberBreakfast.Contracts.Account
{
     public record RegisterRequest
    (
         String Username , 
         String Password ,
         String Email , 
         bool isAdmin = false
         
         
         );
}
