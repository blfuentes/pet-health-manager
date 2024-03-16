using MediatR;
using Microsoft.AspNetCore.Mvc;
using static application.Features.Weights.Queries.GetWeightRegistriesByPet;

namespace webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeightRegistriesController(IMediator mediator) : ControllerBase
{
    [HttpGet("{petId}")]
    public async Task<IEnumerable<GetWeightRegistriesByPetResponse>> GetWeightRegistriesByPetId(int petId)
    {
        var weights = await mediator.Send(new GetWeightRegistriesByPetQuery(petId));
        return weights;
    }
}
