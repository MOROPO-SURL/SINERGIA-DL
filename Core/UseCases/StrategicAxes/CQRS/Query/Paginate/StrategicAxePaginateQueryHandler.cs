using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.CQRS.Query.Paginate;

internal sealed class StrategicAxePaginateQueryHandler :
    AbstractPaginateQueryHandler<StrategicAxe, StrategicAxeId, int, StrategicAxePaginateQuery, StrategicAxeBasicDto>,
    IRequestHandler<StrategicAxePaginateQuery, PaginateQueryResultModel<StrategicAxeBasicDto>>
{
    public StrategicAxePaginateQueryHandler(IStrategicAxeQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}