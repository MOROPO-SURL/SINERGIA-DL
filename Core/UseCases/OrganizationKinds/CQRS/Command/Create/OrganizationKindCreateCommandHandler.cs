using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.CQRS.Command.Create;

internal sealed class OrganizationKindCreateCommandHandler :
    AbstractCreateCommandHandler<OrganizationKind, OrganizationKindId, Guid, OrganizationKindCreateCommand, OrganizationKindDetailDto>,
    IRequestHandler<OrganizationKindCreateCommand, OrganizationKindDetailDto>
{
    private readonly IDataIntegrityServicePort dataIntegrityService;

    public OrganizationKindCreateCommandHandler(IOrganizationKindCommandRepositoryPort entityCommandRepository, IOrganizationKindQueryRepositoryPort entityQueryRepository, IMapper mapper, IDataIntegrityServicePort dataIntegrityService)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
        this.dataIntegrityService = dataIntegrityService;
    }
}