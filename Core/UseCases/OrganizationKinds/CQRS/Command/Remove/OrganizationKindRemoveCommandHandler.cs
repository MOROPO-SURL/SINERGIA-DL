using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.CQRS.Command.Remove;

internal sealed class OrganizationKindRemoveCommandHandler :
    AbstractRemoveCommandHandler<OrganizationKind, OrganizationKindId, Guid, OrganizationKindRemoveCommand>,
    IRequestHandler<OrganizationKindRemoveCommand>
{
    public OrganizationKindRemoveCommandHandler(IOrganizationKindQueryRepositoryPort entityQueryRepository, IOrganizationKindCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}