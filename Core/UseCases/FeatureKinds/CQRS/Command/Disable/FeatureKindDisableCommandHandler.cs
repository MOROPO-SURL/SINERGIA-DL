using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.CQRS.Command.Disable;

internal sealed class FeatureKindDisableCommandHandler :
    AbstractDisableCommandHandler<FeatureKind, FeatureKindId, Guid, FeatureKindDisableCommand>,
    IRequestHandler<FeatureKindDisableCommand>
{
    public FeatureKindDisableCommandHandler(IFeatureKindCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}