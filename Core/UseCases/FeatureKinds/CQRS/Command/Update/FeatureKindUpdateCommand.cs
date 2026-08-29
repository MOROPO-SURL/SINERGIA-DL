using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.CQRS.Command.Update;

public record FeatureKindUpdateCommand(Guid Id, string Name, bool IsEnabled, int Priority, string? Description = null) : IUpdateCommand<Guid, DTOs.FeatureKindDetailDto>;