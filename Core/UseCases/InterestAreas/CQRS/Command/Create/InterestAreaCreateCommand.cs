using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Command.Create;

public record InterestAreaCreateCommand(Guid Id, string Name, string? Description, bool IsEnable) : ICreateCommand<InterestAreaDetailDto>;

