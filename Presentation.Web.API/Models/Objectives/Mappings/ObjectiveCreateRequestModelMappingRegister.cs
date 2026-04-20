using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Create.Addon;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.Objectives.Mappings;

internal sealed class ObjectiveCreateRequestModelMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ObjectiveCreateRequestModel, ObjectiveCreateCommand>()
            .Map(dest => dest.Id, src => Guid.NewGuid())
            .Map(dest => dest.Challanges, src => src.Challanges.Select(item => new ObjectiveChallangeCreateCommandAddon(item.Index, item.Title, item.Description)))
            .Map(dest => dest.Projections, src => src.Projections.Select(item => new ObjectiveProjectionCreateCommandAddon(item.Index, item.Title, item.Description)))
            .Map(dest => dest.Actions, src => src.Actions.Select(item => new ObjectiveActionCreateCommandAddon(item.Index, item.Title, item.Description)))
            .Map(dest => dest, src => src);
    }
}
