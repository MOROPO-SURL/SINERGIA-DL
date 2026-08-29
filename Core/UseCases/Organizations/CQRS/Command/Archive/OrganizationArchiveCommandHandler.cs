using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Archive;

internal sealed class OrganizationArchiveCommandHandler :
    AbstractArchiveCommandHandler<Organization, OrganizationId, Guid, OrganizationArchiveCommand>,
    IRequestHandler<OrganizationArchiveCommand>
{
    public OrganizationArchiveCommandHandler(IOrganizationCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}
