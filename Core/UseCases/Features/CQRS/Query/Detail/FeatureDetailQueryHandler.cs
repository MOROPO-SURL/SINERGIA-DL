using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.CQRS.Query.Detail;

internal sealed class FeatureDetailQueryHandler :
    AbstractDetailQueryHandler<Feature, FeatureId, Guid, FeatureDetailQuery, FeatureDetailDto>,
    IRequestHandler<FeatureDetailQuery, FeatureDetailDto>
{
    public FeatureDetailQueryHandler(IFeatureQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}