using Mapster;
using RVP.Core.Application.Dtos.ElectedPosition;
using RVP.Core.Domain.Entities;


namespace RVP.Core.Application.Mappings.EntitiesToDtos
{
    public class ElectedPositionMappingRegister : IRegister
    {
        public void Register(TypeAdapterConfig mapper) 
        {
            mapper.NewConfig<ElectedPositionDto, ElectedPosition>()
                .Ignore(nameof(ElectedPosition.CandidatePositions))
                .Ignore(nameof(ElectedPosition.ElectionCandidates))
                .Ignore(nameof(ElectedPosition.ElectionPosition));
                

            mapper.NewConfig<ElectedPosition, ElectedPositionDto>()
             .Ignore(nameof(ElectedPosition.CandidatePositions))
             .Ignore(nameof(ElectedPosition.ElectionCandidates))
             .Ignore(nameof(ElectedPosition.ElectionPosition));
        }

    }
}
