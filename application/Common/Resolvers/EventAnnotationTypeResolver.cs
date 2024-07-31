using application.Common.Extensions;
using application.Domain.Entities;
using application.Features.EventAnnotations.Queries;
using AutoMapper;

namespace application.Common.Resolvers;

public class EventAnnotationTypeResolver : IValueResolver<EventAnnotation, GetEventAnnotationsByPetResponse, string>
{
    public string Resolve(EventAnnotation source, GetEventAnnotationsByPetResponse destination, string destMember, ResolutionContext context)
    {
        return source.EventType.GetDescription();
    }
}