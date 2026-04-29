using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClassificationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClassificationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.CQRS.Command.Archive;

internal sealed class ClassificationArchiveCommandHandler :
    AbstractArchiveCommandHandler<Classification, ClassificationId, Guid, ClassificationArchiveCommand>,
    IRequestHandler<ClassificationArchiveCommand>
{
    public ClassificationArchiveCommandHandler(IClassificationCommandRepositoryPort entityCommandRepository, IClassificationQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}