using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClassificationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClassificationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.CQRS.Command.Unarchive;

internal sealed class ClassificationUnarchiveCommandHandler :
    AbstractUnarchiveCommandHandler<Classification, ClassificationId, Guid, ClassificationUnarchiveCommand>,
    IRequestHandler<ClassificationUnarchiveCommand>
{
    public ClassificationUnarchiveCommandHandler(IClassificationCommandRepositoryPort entityCommandRepository, IClassificationQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}