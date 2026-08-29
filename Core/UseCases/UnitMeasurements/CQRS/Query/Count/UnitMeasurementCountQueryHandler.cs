using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Query.Count;

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
