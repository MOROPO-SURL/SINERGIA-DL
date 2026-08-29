using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.DTOs;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Query.Detail;

internal sealed class InterestAreaDetailQueryHandler: AbstractDetailQueryHandler<InterestArea, InterestAreaId, Guid, InterestAreaDetailQuery, InterestAreaDetailDto>,
    IRequestHandler<InterestAreaDetailQuery, InterestAreaDetailDto>
{
    public InterestAreaDetailQueryHandler(IInterestAreaQueryRepositoryPort interestAreaQueryRepository, IMapper mapper) : base(interestAreaQueryRepository, mapper)
    {
    }
}
