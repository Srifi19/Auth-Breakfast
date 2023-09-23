using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberBreakfast.Contracts.Account
{
    public record LoginRequest
    (
        String username,
        String password
        
        );
}
