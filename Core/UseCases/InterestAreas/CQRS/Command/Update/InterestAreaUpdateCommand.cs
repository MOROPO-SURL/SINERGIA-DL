using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Command.Update;

public record InterestAreaUpdateCommand(Guid Id, string Name, string? Description, bool IsEnable) : IUpdateCommand<Guid, DTOs.InterestAreaDetailDto>;

