using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.CQRS.Command.Update;

internal sealed class FeatureUpdateCommandHandler :
    AbstractUpdateCommandHandler<Feature, FeatureId, Guid, FeatureUpdateCommand, FeatureDetailDto>,
    IRequestHandler<FeatureUpdateCommand, FeatureDetailDto>
{
    public FeatureUpdateCommandHandler(IFeatureCommandRepositoryPort entityCommandRepository, IFeatureQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}