using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantsApp.Application.RestaurantHandle.Commands;
using RestaurantsApp.Application.RestaurantHandle.DTOs;
using RestaurantsApp.Application.RestaurantHandle.Queries;

namespace RestaurantsApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantsGetDTO>>> GetAll()
        {
            var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
            if (restaurants is null)
            {
                return NotFound();
            }
            return Ok(restaurants);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<RestaurantsGetDTO>>> GetById([FromRoute]Guid Id)
        {
            var restaurants = await mediator.Send(new GetRestaurantByIdQuery(Id));
            if (restaurants is null)
            {
                return NotFound();
            }
            return Ok(restaurants);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> AddRestaurant(AddRestaurantCommand newRestaurant,[FromServices] IValidator<AddRestaurantCommand> validator)
        {
            var validationResult = validator.Validate(newRestaurant);
            if (validationResult.IsValid)
            {
                var newRestaurantId = await mediator.Send(newRestaurant);
                return Created();
            }
            return BadRequest(validationResult.ToDictionary());
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Guid>> UpdateRestaurant([FromRoute]Guid Id,UpdateRestaurantCommand newRestaurantData, [FromServices] IValidator<UpdateRestaurantCommand> validator)
        {
            newRestaurantData.Id=Id;
            var validationResult = validator.Validate(newRestaurantData);
            if (validationResult.IsValid)
            {
                var result=await mediator.Send(newRestaurantData);
                if (result)
                {
                    return NoContent();
                }
                return NotFound();

            }
            return BadRequest(validationResult.ToDictionary());
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute]Guid Id)
        {
            var result=await mediator.Send(new DeleteRestaurantCommand(Id));
            if(result)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
