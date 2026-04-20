using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Create.Addon;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Create;

public record ObjectiveCreateCommand(Guid Id, int Index, string Title, ObjectiveChallangeCreateCommandAddon[] Challanges, ObjectiveProjectionCreateCommandAddon[] Projections, ObjectiveActionCreateCommandAddon[] Actions, string? Description = null) : ICreateCommand<ObjectiveDetailDto>;