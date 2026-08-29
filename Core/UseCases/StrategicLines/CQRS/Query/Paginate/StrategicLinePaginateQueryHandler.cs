using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.CQRS.Query.Paginate;

internal sealed class StrategicLinePaginateQueryHandler : 
    AbstractPaginateQueryHandler<StrategicLine, StrategicLineId, Guid, StrategicLinePaginateQuery, StrategicLineBasicDto>,
    IRequestHandler<StrategicLinePaginateQuery, PaginateQueryResultModel<StrategicLineBasicDto>>
{
    public StrategicLinePaginateQueryHandler(IStrategicLineQueryRepositoryPort entityQueryRepository)
        : base(entityQueryRepository)
    {
    }
}