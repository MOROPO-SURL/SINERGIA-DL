using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.CQRS.Command.Remove;

internal sealed class FeatureKindRemoveCommandHandler :
    AbstractRemoveCommandHandler<FeatureKind, FeatureKindId, Guid, FeatureKindRemoveCommand>,
    IRequestHandler<FeatureKindRemoveCommand>
{
    public FeatureKindRemoveCommandHandler(IFeatureKindQueryRepositoryPort entityQueryRepository, IFeatureKindCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}