using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberBreakfast.Contracts.Account
{
    public record LoginResponse
    (
        String username,
        String password,
        bool isAdmin,
        bool Successed
        
        );
}
