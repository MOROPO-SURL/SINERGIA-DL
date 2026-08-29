using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Query.List;

internal sealed class DevelopmentActorProfilableOrganizationListQueryHandler :
    AbstractListQueryHandler<Organization, OrganizationId, Guid, OrganizationBasicDto, DevelopmentActorProfilableOrganizationListQuery>,
    IRequestHandler<DevelopmentActorProfilableOrganizationListQuery, OrganizationBasicDto[]>
{
    public DevelopmentActorProfilableOrganizationListQueryHandler(IOrganizationQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}