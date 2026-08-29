using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Create.Addon;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Create;

public record ObjectiveCreateCommand(
    Guid Id, 
    int Index, 
    string Title, 
    ObjectiveChallengeAddonCreateCommand[] Challenges, 
    ObjectiveProjectionAddonCreateCommand[] Projections, 
    ObjectiveActionAddonCreateCommand[] Actions, 
    string? Description = null) : ICreateCommand<ObjectiveDetailDto>;