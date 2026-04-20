using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.DTOs;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.CQRS.Query.Detail;

internal sealed class InterestAreaDetailQueryHandler: AbstractDetailQueryHandler<InterestArea, InterestAreaId, Guid, InterestAreaDetailQuery, InterestAreaDetailDto>,
    IRequestHandler<InterestAreaDetailQuery, InterestAreaDetailDto>
{
    public InterestAreaDetailQueryHandler(IInterestAreaQueryRepositoryPort interestAreaQueryRepository, IMapper mapper) : base(interestAreaQueryRepository, mapper)
    {
    }
}
