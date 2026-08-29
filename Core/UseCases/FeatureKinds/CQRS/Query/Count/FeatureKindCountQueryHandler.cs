using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.CQRS.Query.Count;

public sealed class FeatureKindCountQueryHandler : IRequestHandler<FeatureKindCountQuery, int>
{
    private readonly IFeatureKindQueryRepositoryPort repository;

    public FeatureKindCountQueryHandler(IFeatureKindQueryRepositoryPort repository)
    {
        this.repository = repository;
    }

    public Task<int> Handle(FeatureKindCountQuery request, CancellationToken cancellationToken)
    {
        return repository.CountAsync();
    }
}
