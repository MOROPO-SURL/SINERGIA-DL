using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.CQRS.Command.Remove;

internal sealed class InterestAreaRemoveCommandHandler: AbstractRemoveCommandHandler<InterestArea, InterestAreaId, Guid, InterestAreaRemoveCommand>, IRequestHandler<InterestAreaRemoveCommand>
{
    public InterestAreaRemoveCommandHandler(IInterestAreaCommandRepositoryPort entityCommandRepository, IInterestAreaQueryRepositoryPort entityQueryRepository, IMapper mapper)
    : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
