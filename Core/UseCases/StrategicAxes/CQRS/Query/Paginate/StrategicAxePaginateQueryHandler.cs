using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Query.Paginate;

internal sealed class StrategicAxePaginateQueryHandler :
    AbstractPaginateQueryHandler<StrategicAxe, StrategicAxeId, int, StrategicAxePaginateQuery, StrategicAxeBasicDto>,
    IRequestHandler<StrategicAxePaginateQuery, PaginateQueryResultModel<StrategicAxeBasicDto>>
{
    public StrategicAxePaginateQueryHandler(IStrategicAxeQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}