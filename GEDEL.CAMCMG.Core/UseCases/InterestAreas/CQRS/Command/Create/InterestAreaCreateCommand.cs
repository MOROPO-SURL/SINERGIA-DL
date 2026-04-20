using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.CQRS.Command.Create;

public record InterestAreaCreateCommand(Guid Id, string Name, string? Description, bool IsEnable) : ICreateCommand<InterestAreaDetailDto>;

