using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.CQRS.Command.Update;

internal sealed class FeatureKindUpdateCommandHandler :
    AbstractUpdateCommandHandler<FeatureKind, FeatureKindId, Guid, FeatureKindUpdateCommand, FeatureKindDetailDto>,
    IRequestHandler<FeatureKindUpdateCommand, FeatureKindDetailDto>
{
    public FeatureKindUpdateCommandHandler(IFeatureKindQueryRepositoryPort entityQueryRepository, IFeatureKindCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}