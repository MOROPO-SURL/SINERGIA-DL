using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Create.Addon;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Update.Addon;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Update;

public record ObjectiveUpdateCommand(
    Guid Id, 
    int Index, 
    string Title,
    ObjectiveChallengeCreateCommandAddon[] InChallenges,
    ObjectiveChallengeUpdateCommandAddon[] PatchChallenges,
    ObjectiveChallengeDetailDto[] OutChallenges,
    ObjectiveProjectionCreateCommandAddon[] InProjections, 
    ObjectiveProjectionUpdateCommandAddon[] PatchProjections,
    ObjectiveActionDetailDto[] OutProjections,
    ObjectiveActionCreateCommandAddon[] InActions, 
    ObjectiveActionUpdateCommandAddon[] PatchActions, 
    ObjectiveActionDetailDto[] OutActions,
    string? Description = null) : IUpdateCommand<Guid, ObjectiveDetailDto>;