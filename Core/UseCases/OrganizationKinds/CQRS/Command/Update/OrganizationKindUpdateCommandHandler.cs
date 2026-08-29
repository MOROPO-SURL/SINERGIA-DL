using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.CQRS.Command.Update;

internal sealed class OrganizationKindUpdateCommandHandler :
    AbstractUpdateCommandHandler<OrganizationKind, OrganizationKindId, Guid, OrganizationKindUpdateCommand, OrganizationKindDetailDto>,
    IRequestHandler<OrganizationKindUpdateCommand, OrganizationKindDetailDto>
{
    public OrganizationKindUpdateCommandHandler(IOrganizationKindQueryRepositoryPort entityQueryRepository, IOrganizationKindCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}