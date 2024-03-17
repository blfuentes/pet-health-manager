using MediatR;
using Microsoft.AspNetCore.Mvc;
using static application.Features.Pets.Queries.GetPet;
using static application.Features.Pets.Queries.GetPets;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetsController(IMediator mediator) : ControllerBase
{

    // GET: api/<PetsController>
    [HttpGet]
    public async Task<IEnumerable<GetPetsResponse>> Get()
    {
        var pets = await mediator.Send(new GetPetsQuery());
        return pets;
    }

    // GET api/<PetsController>/5
    [HttpGet("{id}")]
    public async Task<GetPetResponse> Get(int id)
    {
        var pet = await mediator.Send(new GetPetQuery(id));
        return pet;
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
