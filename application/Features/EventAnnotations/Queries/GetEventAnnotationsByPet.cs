using application.Common.Extensions;
using application.Domain.Entities;
using application.Infrastructure;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace application.Features.EventAnnotations.Queries;

public record GetEventAnnotationsByPetQuery(int PetId) : IRequest<IEnumerable<GetEventAnnotationsByPetResponse>>;

public class GetEventAnnotationsByPetHandler(ApiDbContext context, IMapper mapper, ILogger<GetEventAnnotationsByPetHandler> logger)
    : IRequestHandler<GetEventAnnotationsByPetQuery, IEnumerable<GetEventAnnotationsByPetResponse>>
{
    public async Task<IEnumerable<GetEventAnnotationsByPetResponse>> Handle(GetEventAnnotationsByPetQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all event annotations for pet with ID {ID}", request.PetId);

        var eventAnnotations = await context.EventAnnotations
            .Where(w => w.PetId == request.PetId)
            .ToListAsync(cancellationToken);

        return mapper.Map<IEnumerable<GetEventAnnotationsByPetResponse>>(eventAnnotations);
    }
}

public class GetEventAnnotationsByPetMappingProfile : Profile
{
    public GetEventAnnotationsByPetMappingProfile()
    {
        CreateMap<EventAnnotation, GetEventAnnotationsByPetResponse>();
        CreateMap<GetEventAnnotationsByPetResponse, EventAnnotation>();
        CreateMap<EventAnnotationType, string>().ConvertUsing(r => r.GetDescription());
    }
}

public record GetEventAnnotationsByPetResponse(int Id, int PetId, DateTime Date, string EventType, string Note);
