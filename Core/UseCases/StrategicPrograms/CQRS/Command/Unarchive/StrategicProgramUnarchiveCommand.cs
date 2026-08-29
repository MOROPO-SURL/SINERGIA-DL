using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Unarchive;

public record StrategicProgramUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;