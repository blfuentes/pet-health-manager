using application.Domain.Entities;
using application.Infrastructure;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace application.Features.Pets.Queries;

public class GetPets
{
    public record GetPetsQuery : IRequest<IEnumerable<GetPetsResponse>>
    {

    }

    public class GetPetsHandler(ApiDbContext context, IMapper mapper, ILogger<GetPetsHandler> logger) 
        : IRequestHandler<GetPetsQuery, IEnumerable<GetPetsResponse>>
    {
        public async Task<IEnumerable<GetPetsResponse>> Handle(GetPetsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all pets");

            return await context.Pets.ProjectTo<GetPetsResponse>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }
    }

    public class GetPetsMappingProfile : Profile
    {
        public GetPetsMappingProfile()
        {
            CreateMap<Pet, GetPetsResponse>();
            CreateMap<GetPetsResponse, Pet>();
            CreateMap<Color, string>().ConvertUsing(r => r.Name);
            CreateMap<string, Color>().ConvertUsing(source => new Color { Name = source });
        }
    }

    public record GetPetsResponse(int Id, string Name, string Species, string Breed, IEnumerable<string> Colors, DateTime Birth, DateTime? Death, DateTime Adoption);
}
