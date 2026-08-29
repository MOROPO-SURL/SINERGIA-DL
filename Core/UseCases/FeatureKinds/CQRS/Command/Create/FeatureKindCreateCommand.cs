using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.CQRS.Command.Create;

public record FeatureKindCreateCommand(string Name, bool IsEnabled, int Priority, string? Description = null) : ICreateCommand<FeatureKindDetailDto>;