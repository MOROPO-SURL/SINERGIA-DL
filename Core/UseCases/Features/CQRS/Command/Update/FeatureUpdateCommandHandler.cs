using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Features.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Features.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Features.CQRS.Command.Update;

internal sealed class FeatureUpdateCommandHandler :
    AbstractUpdateCommandHandler<Feature, FeatureId, Guid, FeatureUpdateCommand, FeatureDetailDto>,
    IRequestHandler<FeatureUpdateCommand, FeatureDetailDto>
{
    public FeatureUpdateCommandHandler(IFeatureCommandRepositoryPort entityCommandRepository, IFeatureQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}