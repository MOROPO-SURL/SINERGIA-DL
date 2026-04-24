using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Features.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Features.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Features.CQRS.Query.List;

internal sealed class FeatureListQueryHandler :
    AbstractListQueryHandler<Feature, FeatureId, Guid, FeatureDetailDto, FeatureListQuery>,
    IRequestHandler<FeatureListQuery, FeatureDetailDto[]>
{
    public FeatureListQueryHandler(IFeatureQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}