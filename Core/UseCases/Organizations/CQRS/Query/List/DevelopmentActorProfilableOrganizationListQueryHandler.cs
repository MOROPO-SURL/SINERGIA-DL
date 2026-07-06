using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Query.List;

internal sealed class DevelopmentActorProfilableOrganizationListQueryHandler :
    AbstractListQueryHandler<Organization, OrganizationId, Guid, OrganizationBasicDto, DevelopmentActorProfilableOrganizationListQuery>,
    IRequestHandler<DevelopmentActorProfilableOrganizationListQuery, OrganizationBasicDto[]>
{
    public DevelopmentActorProfilableOrganizationListQueryHandler(IOrganizationQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}