using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Update.Addon;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.Objectives.Mappings;

internal sealed class ObjectiveUpdateRequestModelMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ObjectiveUpdateRequestModel, ObjectiveUpdateCommand>()
            .Map(dest => dest.Challanges, src => src.Challanges.Select(item => new ObjectiveChallangeUpdateCommandAddon(item.Id, item.Index, item.Title, item.Description)))
            .Map(dest => dest.Projections, src => src.Projections.Select(item => new ObjectiveProjectionUpdateCommandAddon(item.Id, item.Index, item.Title, item.Description)))
            .Map(dest => dest.Actions, src => src.Actions.Select(item => new ObjectiveActionUpdateCommandAddon(item.Id, item.Index, item.Title, item.Description)))
            .Map(dest => dest, src => src);
    }
}