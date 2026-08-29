using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Create.Addon;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Update.Addon;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Update;

public record ObjectiveUpdateCommand(
    Guid Id, 
    int Index, 
    string Title,
    ObjectiveChallengeAddonCreateCommand[] InChallenges,
    ObjectiveChallengeAddonUpdateCommand[] PatchChallenges,
    ObjectiveChallengeDetailDto[] OutChallenges,
    ObjectiveProjectionAddonCreateCommand[] InProjections, 
    ObjectiveProjectionAddonUpdateCommand[] PatchProjections,
    ObjectiveActionDetailDto[] OutProjections,
    ObjectiveActionAddonCreateCommand[] InActions, 
    ObjectiveActionAddonUpdateCommand[] PatchActions, 
    ObjectiveActionDetailDto[] OutActions,
    string? Description = null) : IUpdateCommand<Guid, ObjectiveDetailDto>;