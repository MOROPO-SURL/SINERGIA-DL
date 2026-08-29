using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Command.Update;

public record ClassificationUpdateCommand(Guid Id, string Name, int Priority, bool IsEnabled, string? Description = null) : IUpdateCommand<Guid, DTOs.ClassificationDetailDto>;