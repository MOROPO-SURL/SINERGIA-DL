using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClasificationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClasificationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.CQRS.Command.Unarchive;

internal sealed class ClasificationUnarchiveCommandHandler :
    AbstractUnarchiveCommandHandler<Clasification, ClasificationId, Guid, ClasificationUnarchiveCommand>,
    IRequestHandler<ClasificationUnarchiveCommand>
{
    public ClasificationUnarchiveCommandHandler(IClasificationCommandRepositoryPort entityCommandRepository, IClasificationQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}