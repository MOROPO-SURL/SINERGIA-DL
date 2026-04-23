using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClasificationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClasificationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.CQRS.Command.Remove;

internal sealed class ClasificationRemoveCommandHandler :
    AbstractRemoveCommandHandler<Clasification, ClasificationId, Guid, ClasificationRemoveCommand>,
    IRequestHandler<ClasificationRemoveCommand>
{
    public ClasificationRemoveCommandHandler(IClasificationQueryRepositoryPort entityQueryRepository, IClasificationCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}