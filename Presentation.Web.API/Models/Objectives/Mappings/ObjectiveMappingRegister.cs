using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Create.Addon;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Update.Addon;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Models.Objectives.Mappings;

internal class ObjectiveMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), ObjectivePaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<ObjectiveDetailDto, Guid>()
            .MapWith(src => src.Id);

        config.NewConfig<Guid, ObjectiveDetailQuery>()
            .MapWith(src => new ObjectiveDetailQuery(src));

        config.NewConfig<Guid, ObjectiveRemoveCommand>()
            .MapWith(src => new ObjectiveRemoveCommand(src));

        config.NewConfig<Guid, ObjectiveEnableCommand>()
            .MapWith(src => new ObjectiveEnableCommand(src));

        config.NewConfig<Guid, ObjectiveDisableCommand>()
            .MapWith(src => new ObjectiveDisableCommand(src));

        config.NewConfig<Guid, ObjectiveArchiveCommand>()
            .MapWith(src => new ObjectiveArchiveCommand(src));

        config.NewConfig<Guid, ObjectiveUnarchiveCommand>()
            .MapWith(src => new ObjectiveUnarchiveCommand(src));

        config.NewConfig<ObjectiveCreateRequestModel, ObjectiveCreateCommand>()
            .Map(dest => dest.Id, src => Guid.NewGuid())
            .Map(dest => dest.Challenges, src => src.Challenges.Select(item => new ObjectiveChallengeAddonCreateCommand(item.Index, item.Title, item.Description)))
            .Map(dest => dest.Projections, src => src.Projections.Select(item => new ObjectiveProjectionAddonCreateCommand(item.Index, item.Title, item.Description)))
            .Map(dest => dest.Actions, src => src.Actions.Select(item => new ObjectiveActionAddonCreateCommand(item.Index, item.Title, item.Description)))
            .Map(dest => dest, src => src);

        config.NewConfig<ObjectiveUpdateRequestModel, ObjectiveUpdateCommand>()
            .Map(dest => dest.InChallenges, src => src.InChallenges.Select(item => new ObjectiveChallengeAddonCreateCommand(item.Index, item.Title, item.Description)))
            .Map(dest => dest.PatchChallenges, src => src.PatchChallenges.Select(item => new ObjectiveChallengeAddonUpdateCommand(item.Id, item.Index, item.Title, item.Description)))
            .Map(dest => dest.OutChallenges, src => src.OutChallenges.Select(item => new ObjectiveChallengeDetailDto(item.Id, item.Index, item.Title, item.Description)))
            .Map(dest => dest.InProjections, src => src.InProjections.Select(item => new ObjectiveProjectionAddonCreateCommand(item.Index, item.Title, item.Description)))
            .Map(dest => dest.PatchProjections, src => src.PatchProjections.Select(item => new ObjectiveProjectionAddonUpdateCommand(item.Id, item.Index, item.Title, item.Description)))
            .Map(dest => dest.OutProjections, src => src.OutProjections.Select(item => new ObjectiveProjectionDetailDto(item.Id, item.Index, item.Title, item.Description)))
            .Map(dest => dest.InActions, src => src.InActions.Select(item => new ObjectiveActionAddonCreateCommand(item.Index, item.Title, item.Description)))
            .Map(dest => dest.PatchActions, src => src.PatchActions.Select(item => new ObjectiveActionAddonUpdateCommand(item.Id, item.Index, item.Title, item.Description)))
            .Map(dest => dest.OutActions, src => src.OutActions.Select(item => new ObjectiveActionDetailDto(item.Id, item.Index, item.Title, item.Description)))
            .Map(dest => dest, src => src);
    }
}
