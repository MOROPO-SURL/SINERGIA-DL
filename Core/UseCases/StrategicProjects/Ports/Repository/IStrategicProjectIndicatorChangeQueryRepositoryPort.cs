using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.Ports.Repository;

public interface IStrategicProjectIndicatorChangeQueryRepositoryPort
{
    IEnumerable<ProjectIndicatorChange> GetIndicatorChangeListByProjectActionIndicator(StrategicProjectId programId, ProjectIndicatorId indicatorId);

    IEnumerable<ProjectIndicatorChange> GetIndicatorChangeLastsByProject(StrategicProjectId programId);
}