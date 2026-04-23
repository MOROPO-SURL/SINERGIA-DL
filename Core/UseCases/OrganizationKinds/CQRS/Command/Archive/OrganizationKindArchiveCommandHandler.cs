using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.CQRS.Command.Archive;

internal sealed class OrganizationKindArchiveCommandHandler :
    AbstractArchiveCommandHandler<OrganizationKind, OrganizationKindId, Guid, OrganizationKindArchiveCommand>,
    IRequestHandler<OrganizationKindArchiveCommand>
{
    public OrganizationKindArchiveCommandHandler(IOrganizationKindCommandRepositoryPort entityCommandRepository, IOrganizationKindQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
