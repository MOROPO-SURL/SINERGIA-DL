using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Entities;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.Ports.Repository;

public interface IStrategicProgramActionIndicatorChangeQueryRepositoryPort
{
    IEnumerable<ProgramActionIndicatorChange> GetIndicatorChangeListByProgramActionIndicator(StrategicProgramId programId, ProgramActionId actionId, ProgramActionIndicatorId indicatorId);

    IEnumerable<ProgramActionIndicatorChange> GetIndicatorChangeLastsByProgram(StrategicProgramId programId);
}