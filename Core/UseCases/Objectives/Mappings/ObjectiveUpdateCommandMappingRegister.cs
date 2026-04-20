using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.Mappings;

internal sealed class ObjectiveUpdateCommandMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ObjectiveUpdateCommand, Objective>()
            .Map(dest => dest.Id, src => new ObjectiveId(src.Id))
            .Map(dest => dest.Challenges, src => src.Challanges.Select(item => new ObjectiveChallenge(new ObjectiveChallengeId(item.Id), new ObjectiveId(src.Id), item.Index, item.Title, item.Description)))
            .Map(dest => dest.Projections, src => src.Projections.Select(item => new ObjectiveProjection(new ObjectivActionId(item.Id), new ObjectiveId(src.Id), item.Index, item.Title, item.Description)))
            .Map(dest => dest.Actions, src => src.Actions.Select(item => new ObjectiveAction(new ObjectiveActionId(item.Id), new ObjectiveId(src.Id), item.Index, item.Title, item.Description)))
            .Map(dest => dest, src => src);
    }
}
