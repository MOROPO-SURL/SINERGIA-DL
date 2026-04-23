using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.CQRS.Command.Enable;

internal sealed class OrganizationKindEnableCommandHandler :
    AbstractEnableCommandHandler<OrganizationKind, OrganizationKindId, Guid, OrganizationKindEnableCommand>,
    IRequestHandler<OrganizationKindEnableCommand>
{
    public OrganizationKindEnableCommandHandler(IOrganizationKindCommandRepositoryPort entityCommandRepository, IOrganizationKindQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}