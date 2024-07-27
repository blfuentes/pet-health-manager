using application.Domain.Entities;
using application.Infrastructure;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace application.Features.Pets.Queries;

public class GetPet
{
    public record GetPetQuery(int Id, bool loadWeight) : IRequest<GetPetResponse>;

    public class GetPetHandler(ApiDbContext context, IMapper mapper, ILogger<GetPetHandler> logger)
        : IRequestHandler<GetPetQuery, GetPetResponse>
    {
        public async Task<GetPetResponse> Handle(GetPetQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting pet with ID {ID}", request.Id);

            var pet = await context.Pets
                .FindAsync(request.Id);

            if (pet is not null)
            {
                await context.Entry(pet).Collection(p => p.Colors).LoadAsync(cancellationToken);

                if (request.loadWeight)
                    await context.Entry(pet).Collection(p => p.WeightRegistries).LoadAsync(cancellationToken);
            }

            return mapper.Map<GetPetResponse>(pet);
        }
    }

    public class GetPetMappingProfile : Profile
    {
        public GetPetMappingProfile()
        {
            CreateMap<Pet, GetPetResponse>()
                .ForMember(dest => dest.Weights, opt => opt.MapFrom(ori => ori.WeightRegistries));
            CreateMap<GetPetResponse, Pet>();
            CreateMap<Color, string>().ConvertUsing(r => r.Name);
            CreateMap<string, Color>().ConvertUsing(source => new Color { Name = source });
        }
    }

    public class GetPetResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Species { get; set; }
        public required string Breed { get; set; }
        public IEnumerable<string> Colors { get; set; } = [];
        public DateTime Birth { get; set; }
        public DateTime? Death { get; set; }
        public DateTime Adoption { get; set; }
        public required string ImgContent { get; set; }
        public IEnumerable<WeightRegistry> Weights { get; set; } = [];
    }
}
