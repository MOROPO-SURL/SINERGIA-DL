using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.CQRS.Query.Count;

public sealed class UnitMeasurementCountQueryHandler : IRequestHandler<UnitMeasurementCountQuery, int>
{
    private readonly IUnitMeasurementQueryRepositoryPort repository;

    public UnitMeasurementCountQueryHandler(IUnitMeasurementQueryRepositoryPort repository)
    {
        this.repository = repository;
    }

    public Task<int> Handle(UnitMeasurementCountQuery request, CancellationToken cancellationToken)
    {
        return repository.CountAsync();
    }
}
