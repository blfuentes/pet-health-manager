using application.Domain.Entities;
using application.Infrastructure;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace application.Features.Pets.Queries;

public class GetPets
{
    public class GetPetsQuery : IRequest<IEnumerable<GetPetsResponse>>
    {

    }

    public class GetPetsHandler : IRequestHandler<GetPetsQuery, IEnumerable<GetPetsResponse>>
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public GetPetsHandler(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetPetsResponse>> Handle(GetPetsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Pets.ProjectTo<GetPetsResponse>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }
    }

    public class GetProductsMappingProfile : Profile
    {
        public GetProductsMappingProfile()
        {
            CreateMap<Pet, GetPetsResponse>();
            CreateMap<GetPetsResponse, Pet>();
            CreateMap<Color, string>().ConvertUsing(r => r.Name);
            CreateMap<string, Color>().ConvertUsing(source => new Color { Name = source });
        }
    }

    public record GetPetsResponse(int Id, string Name, string Species, string Breed, IEnumerable<string> Colors, DateTime Birth, DateTime? Death, DateTime Adoption);
}
