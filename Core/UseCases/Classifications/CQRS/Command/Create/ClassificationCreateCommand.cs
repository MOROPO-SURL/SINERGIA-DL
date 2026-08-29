using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Command.Create;

public record ClassificationCreateCommand(string Name, int Priority, bool IsEnabled, string? Description = null) : ICreateCommand<ClassificationDetailDto>;