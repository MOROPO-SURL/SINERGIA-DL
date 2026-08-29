using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.CQRS.Query.List;

internal sealed class FeatureListQueryHandler :
    AbstractListQueryHandler<Feature, FeatureId, Guid, FeatureDetailDto, FeatureListQuery>,
    IRequestHandler<FeatureListQuery, FeatureDetailDto[]>
{
    public FeatureListQueryHandler(IFeatureQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}