using application.Domain.Entities;
using application.Infrastructure;
using AutoMapper;
using MediatR;

namespace application.Features.Pets.Queries;

public class GetPet
{
    public record GetPetQuery(int Id) : IRequest<GetPetResponse>;

    public class GetPetHandler(ApiDbContext context, IMapper mapper) : IRequestHandler<GetPetQuery, GetPetResponse>
    {
        public async Task<GetPetResponse> Handle(GetPetQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<GetPetResponse>(await context.Pets.FindAsync(request.Id));
        }
    }

    public class GetPetMappingProfile : Profile
    {
        public GetPetMappingProfile()
        {
            CreateMap<Pet, GetPetResponse>();
            CreateMap<GetPetResponse, Pet>();
            CreateMap<Color, string>().ConvertUsing(r => r.Name);
            CreateMap<string, Color>().ConvertUsing(source => new Color { Name = source });
        }
    }

    public record GetPetResponse(int Id, string Name, string Species, string Breed, DateTime Birth, DateTime? Death, DateTime Adoption);
}
