using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.Ports.Repository;

public interface IStrategicProgramActionIndicatorChangeQueryRepositoryPort
{
    IEnumerable<ProgramActionIndicatorChange> GetIndicatorChangeListByProgramActionIndicator(StrategicProgramId programId, ProgramActionId actionId, ProgramActionIndicatorId indicatorId);

    IEnumerable<ProgramActionIndicatorChange> GetIndicatorChangeLastsByProgram(StrategicProgramId programId);
}