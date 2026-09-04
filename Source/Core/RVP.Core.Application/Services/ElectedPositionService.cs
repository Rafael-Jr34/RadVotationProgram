using MapsterMapper;
using RVP.Core.Application.Dtos.ElectedPosition;
using RVP.Core.Application.Interfaces;
using RVP.Core.Domain.Entities;
using RVP.Core.Domain.Interfaces;


namespace RVP.Core.Application.Services
{
    public class ElectedPositionService : EditService<ElectedPosition, ElectedPositionDto>, IElectedPositionService
    {
        private readonly IElectedPositionRepository _electedPositionRepository;
    
        private readonly IMapper _mapper;
        public ElectedPositionService(IMapper mapper, IElectedPositionRepository electedPositionRepository) : base(mapper, electedPositionRepository)
        {
            _electedPositionRepository = electedPositionRepository;
            _mapper = mapper;
        }
    }
}
