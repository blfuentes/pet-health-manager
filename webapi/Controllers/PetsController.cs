using MediatR;
using Microsoft.AspNetCore.Mvc;
using static application.Features.Pets.Queries.GetPets;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PetsController(IMediator mediator) => _mediator = mediator;

    // GET: api/<PetsController>
    [HttpGet]
    public async Task<IEnumerable<GetPetsResponse>> Get()
    {
        var pets = await _mediator.Send(new GetPetsQuery());
        return pets;
    }

    // GET api/<PetsController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<PetsController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<PetsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<PetsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
