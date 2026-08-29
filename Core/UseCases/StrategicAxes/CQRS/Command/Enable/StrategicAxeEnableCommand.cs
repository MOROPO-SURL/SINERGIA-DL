using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.CQRS.Command.Enable;

public record StrategicAxeEnableCommand(int Id) : IEnableCommand<int>;