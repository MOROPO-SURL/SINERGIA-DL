using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.Ports.Repository;

public interface IStrategicLineCommandRepositoryPort
{
    void TrackChanges(StrategicLine entity);

    Task AddAsync(StrategicLine entity, bool commit = true);

    Task UpdateAsync(StrategicLine entity, bool commit = true);

    Task DeleteAsync(StrategicLine entity, bool commit = true);
}