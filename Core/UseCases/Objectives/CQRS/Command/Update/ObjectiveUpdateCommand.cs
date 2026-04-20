using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Update.Addon;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Update;

public record ObjectiveUpdateCommand(Guid Id, int Index, string Title, ObjectiveChallangeUpdateCommandAddon[] Challanges, ObjectiveProjectionUpdateCommandAddon[] Projections, ObjectiveActionUpdateCommandAddon[] Actions, string? Description = null) : IUpdateCommand<Guid, ObjectiveDetailDto>;