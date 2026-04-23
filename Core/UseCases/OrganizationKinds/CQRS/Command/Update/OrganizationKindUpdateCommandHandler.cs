using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.CQRS.Command.Update;

internal sealed class OrganizationKindUpdateCommandHandler :
    AbstractUpdateCommandHandler<OrganizationKind, OrganizationKindId, Guid, OrganizationKindUpdateCommand, OrganizationKindDetailDto>,
    IRequestHandler<OrganizationKindUpdateCommand, OrganizationKindDetailDto>
{
    public OrganizationKindUpdateCommandHandler(IOrganizationKindQueryRepositoryPort entityQueryRepository, IOrganizationKindCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}