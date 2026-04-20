using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.Mappings;

internal sealed class ObjectiveDetailDtoMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Objective, ObjectiveDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Challanges, src => src.Challenges.Select(entity => new ObjectiveChallangeDetailDto(entity.Id.Value, entity.Index, entity.Title, entity.Description)))
            .Map(dest => dest.Proyections, src => src.Projections.Select(entity => new ObjectiveProyectionDetailDto(entity.Id.Value, entity.Index, entity.Title, entity.Description)))
            .Map(dest => dest.Actions, src => src.Actions.Select(entity => new ObjectiveActionDetailDto(entity.Id.Value, entity.Index, entity.Title, entity.Description)))
            .Map(dest => dest, src => src);
    }
}
