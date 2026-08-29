using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.CQRS.Query.Count;

public sealed class OrganizationKindCountQueryHandler : IRequestHandler<OrganizationKindCountQuery, int>
{
    private readonly IOrganizationKindQueryRepositoryPort repository;

    public OrganizationKindCountQueryHandler(IOrganizationKindQueryRepositoryPort repository)
    {
        this.repository = repository;
    }

    public Task<int> Handle(OrganizationKindCountQuery request, CancellationToken cancellationToken)
    {
        return repository.CountAsync();
    }
}
