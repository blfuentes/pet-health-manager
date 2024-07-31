using application.Features.EventAnnotations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventAnnotationsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{petId}")]
    public async Task<IEnumerable<GetEventAnnotationsByPetResponse>> GetEventAnnotationsByPetId(int petId)
    {
        var weights = await mediator.Send(new GetEventAnnotationsByPetQuery(petId));
        return weights;
    }
}

