using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.CQRS.Query.Count;

public sealed class StrategicProjectKindCountQueryHandler : IRequestHandler<StrategicProjectKindCountQuery, int>
{
    private readonly IStrategicProjectKindQueryRepositoryPort repository;

    public StrategicProjectKindCountQueryHandler(IStrategicProjectKindQueryRepositoryPort repository)
    {
        this.repository = repository;
    }

    public Task<int> Handle(StrategicProjectKindCountQuery request, CancellationToken cancellationToken)
    {
        return repository.CountAsync();
    }
}
