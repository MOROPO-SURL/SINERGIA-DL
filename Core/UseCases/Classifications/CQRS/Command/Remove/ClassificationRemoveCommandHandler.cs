using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClassificationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClassificationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.CQRS.Command.Remove;

internal sealed class ClassificationRemoveCommandHandler :
    AbstractRemoveCommandHandler<Classification, ClassificationId, Guid, ClassificationRemoveCommand>,
    IRequestHandler<ClassificationRemoveCommand>
{
    public ClassificationRemoveCommandHandler(IClassificationQueryRepositoryPort entityQueryRepository, IClassificationCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}