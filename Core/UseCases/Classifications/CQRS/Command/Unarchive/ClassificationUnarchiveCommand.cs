using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Command.Unarchive;

public record ClassificationUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;