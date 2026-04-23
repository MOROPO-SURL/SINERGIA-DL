using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClasificationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClasificationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.CQRS.Command.Archive;

internal sealed class ClasificationArchiveCommandHandler :
    AbstractArchiveCommandHandler<Clasification, ClasificationId, Guid, ClasificationArchiveCommand>,
    IRequestHandler<ClasificationArchiveCommand>
{
    public ClasificationArchiveCommandHandler(IClasificationCommandRepositoryPort entityCommandRepository, IClasificationQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}