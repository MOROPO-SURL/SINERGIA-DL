using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.CQRS.Command.Disable;

internal sealed class OrganizationKindDisableCommandHandler :
    AbstractDisableCommandHandler<OrganizationKind, OrganizationKindId, Guid, OrganizationKindDisableCommand>,
    IRequestHandler<OrganizationKindDisableCommand>
{
    public OrganizationKindDisableCommandHandler(IOrganizationKindCommandRepositoryPort entityCommandRepository, IOrganizationKindQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
