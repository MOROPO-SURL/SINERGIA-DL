using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF; 
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.UnitMeasurements;

internal sealed class UnitMeasurementCommandRepositoryPortAdapter: AbstractEntityCommandRepositoryPortAdapter<UnitMeasurement, UnitMeasurementId, Guid>, IUnitMeasurementCommandRepositoryPort
{
    public UnitMeasurementCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}
