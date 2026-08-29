using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.CQRS.Command.Remove;

internal sealed class FeatureRemoveCommandHandler :
    AbstractRemoveCommandHandler<Feature, FeatureId, Guid, FeatureRemoveCommand>,
    IRequestHandler<FeatureRemoveCommand>
{
    public FeatureRemoveCommandHandler(IFeatureCommandRepositoryPort entityCommandRepository, IMapper mapper) 
        : base(entityCommandRepository, mapper)
    {
    }
}