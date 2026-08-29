using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Command.Disable;

internal sealed class InterestAreaDisableCommandHandler: AbstractDisableCommandHandler<InterestArea, InterestAreaId, Guid, InterestAreaDisableCommand>,
IRequestHandler<InterestAreaDisableCommand>
{
    public InterestAreaDisableCommandHandler(IInterestAreaCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}
