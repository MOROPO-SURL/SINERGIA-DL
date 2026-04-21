using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.CQRS.Query.Paginate;

internal sealed class InterestAreaPaginateQueryHandler: AbstractPaginateQueryHandler<InterestArea, InterestAreaId, Guid, InterestAreaPaginateQuery, InterestAreaBasicDto>,
IRequestHandler<InterestAreaPaginateQuery, PaginateQueryResultModel<InterestAreaBasicDto>>
{
    public InterestAreaPaginateQueryHandler(IInterestAreaQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}
