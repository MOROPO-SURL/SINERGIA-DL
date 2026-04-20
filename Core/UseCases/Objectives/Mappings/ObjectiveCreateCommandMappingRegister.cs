using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.Mappings;

internal sealed class ObjectiveCreateCommandMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ObjectiveCreateCommand, Objective>()
            .Map(dest => dest.Id, src => new ObjectiveId(src.Id))
            .Map(dest => dest.Challenges, src => src.Challanges.Select(item => new ObjectiveChallenge(new ObjectiveChallengeId(Guid.NewGuid()), new ObjectiveId(src.Id), item.Index, item.Title, item.Description)))
            .Map(dest => dest.Projections, src => src.Projections.Select(item => new ObjectiveProjection(new ObjectivActionId(Guid.NewGuid()), new ObjectiveId(src.Id), item.Index, item.Title, item.Description)))
            .Map(dest => dest.Actions, src => src.Actions.Select(item => new ObjectiveAction(new ObjectiveActionId(Guid.NewGuid()), new ObjectiveId(src.Id), item.Index, item.Title, item.Description)))
            .Map(dest => dest, src => src);
    }
}
