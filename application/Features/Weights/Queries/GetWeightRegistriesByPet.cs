using application.Domain.Entities;
using application.Infrastructure;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace application.Features.Weights.Queries;

public class GetWeightRegistriesByPet
{
    public record GetWeightRegistriesByPetQuery(int PetId) : IRequest<IEnumerable<GetWeightRegistriesByPetResponse>>;

    public class GetWeightRegistriesByPetHandler(ApiDbContext context, IMapper mapper, ILogger<GetWeightRegistriesByPetHandler> logger) 
        : IRequestHandler<GetWeightRegistriesByPetQuery, IEnumerable<GetWeightRegistriesByPetResponse>>
    {
        public async Task<IEnumerable<GetWeightRegistriesByPetResponse>> Handle(GetWeightRegistriesByPetQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all weights for pet with ID {ID}", request.PetId);

            return await context.WeightRegistries
                .Where(w => w.PetId == request.PetId)
                .ProjectTo<GetWeightRegistriesByPetResponse>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class GetWeightsByPetMappingProfile : Profile
    {
        public GetWeightsByPetMappingProfile()
        {
            CreateMap<WeightRegistry, GetWeightRegistriesByPetResponse>();
            CreateMap<GetWeightRegistriesByPetResponse, WeightRegistry>();
        }
    }

    public record GetWeightRegistriesByPetResponse(int Id, int PetId, DateTime Date, int Weight);
}