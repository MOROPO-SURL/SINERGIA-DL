using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.InterestAreaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Command.Remove;

internal sealed class InterestAreaRemoveCommandHandler: AbstractRemoveCommandHandler<InterestArea, InterestAreaId, Guid, InterestAreaRemoveCommand>, IRequestHandler<InterestAreaRemoveCommand>
{
    public InterestAreaRemoveCommandHandler(IInterestAreaCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, mapper)
    {
    }
}
