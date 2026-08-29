using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.CQRS.Command.Create;

public record PDLModalityCreateCommand(Guid Id, bool IsEnabled, string Name, int Priority, string? Description = null) : ICreateCommand<PDLModalityDetailDto>;