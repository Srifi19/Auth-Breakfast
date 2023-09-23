using BuberBreakfast.Contracts.Breakfast;
using BurberBreakfast.Models;
using BurberBreakfast.ServiceError;
using BurberBreakfast.Services.BreakfastServices;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using static BurberBreakfast.ServiceError.Errors;

namespace BurberBreakfast.Controllers
{


    public class BreakfastController : ApiController
    {
        private readonly IBreakfastService _breakfastService;
        public BreakfastController(IBreakfastService breakfastService)
        {
            _breakfastService = breakfastService;
        }
        [HttpPost]
        public IActionResult CreateBreakfast(BreakfastRequest request)
        {
          
            var breakfast = new Breakfast(
                   Guid.NewGuid(),
                   request.Name,
                   request.Description,
                   request.StartDateTime,
                   request.EndDateTime,
                   DateTime.UtcNow
                   );
            ErrorOr<Created> createBreakfastResult = _breakfastService.CreateBreakfast(breakfast );


            return createBreakfastResult.Match(
                    created => CreatedAsGetBreakfast(breakfast),
                    errors => Problem(errors));
        }

     

        [HttpGet("{id:guid}")]
        public IActionResult GetBreakfast(Guid id)
        {
  
            ErrorOr<Breakfast> getBreakfastResult = _breakfastService.GetBreakfast(id);
            return getBreakfastResult.Match(
                    breakfast => Ok(MapBreakfastResponse(breakfast)),
                    errors => Problem(errors));

        }



        [HttpPut("{id:guid}")]
        public IActionResult UpsertBreakfast(Guid id , BreakfastRequest request)
        {
            Breakfast breakfast = new(
                    id,
                    request.Name,
                    request.Description,
                    request.StartDateTime,
                    request.EndDateTime,
                    DateTime.UtcNow
                );

            ErrorOr<UpsertedBreakfast> getUpsertBreakfastResult = _breakfastService.UpdateBreakfast(breakfast);

            if (getUpsertBreakfastResult.IsError) return Problem(getUpsertBreakfastResult.Errors);



            return getUpsertBreakfastResult.Match(
                    upserted => upserted.isNewlyCreated ? CreatedAsGetBreakfast(breakfast): NoContent(),
                    errors => Problem(errors));
        }



        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {
            ErrorOr<Deleted> getDeletedBreakfasrResult = _breakfastService.DeleteBreakfast(id);
            
        
            return getDeletedBreakfasrResult.Match(
                    deleted => NoContent(),
                    errors => Problem(errors)); 
        }




        [HttpGet]
        public IActionResult GetAllBreakfasts()
        {
            ErrorOr<IEnumerable<Breakfast>> getAllBreakfastsResult = _breakfastService.GetAllBreakfasts();
           
            return getAllBreakfastsResult.Match(
                breakfasts => Ok(breakfasts.Select(b => MapBreakfastResponse(b))),
                errors => Problem(errors));
        }

        private static BreakfastResponse MapBreakfastResponse(Models.Breakfast breakfast)
        {
            return new BreakfastResponse(
                   breakfast.Id,
                   breakfast.Name,
                   breakfast.Description,
                   breakfast.StartDateTime,
                   breakfast.EndDateTime,
                   breakfast.LastModifiedDateTime
                 
                );
        }

        private CreatedAtActionResult CreatedAsGetBreakfast(Breakfast breakfast)
        {
             return CreatedAtAction(
                actionName: nameof(GetBreakfast) ,
                routeValues: new { breakfast.Id} ,
                value: MapBreakfastResponse(breakfast));
        }
    }
}
