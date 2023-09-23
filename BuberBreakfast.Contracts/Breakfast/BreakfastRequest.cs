using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberBreakfast.Contracts.Breakfast
{
     public record BreakfastRequest(
             string Name,
             string Description,
             DateTime StartDateTime,
             DateTime EndDateTime

       );
}
