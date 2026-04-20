using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.CQRS.Command.Update;

public record InterestAreaUpdateCommand(Guid Id, string Name, string? Description, bool IsEnable) : IUpdateCommand<Guid, DTOs.InterestAreaDetailDto>;

