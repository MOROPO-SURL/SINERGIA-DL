using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivities.CQRS.Command.Archive;

public record EconomicActivityArchiveCommand(int Id) : IArchiveCommand<int>;