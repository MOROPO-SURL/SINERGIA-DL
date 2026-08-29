using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.CQRS.Query.Paginate;

internal sealed class PDLOperationReportPaginateQueryHandler :
    AbstractPaginateQueryHandler<PDLOperationReport, OperationReportId, long, PDLOperationReportPaginateQuery, PDLOperationReportBasicDto>,
    IRequestHandler<PDLOperationReportPaginateQuery, PaginateQueryResultModel<PDLOperationReportBasicDto>>
{
    public PDLOperationReportPaginateQueryHandler(IPDLOperationReportQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<PDLOperationReport, object>> OrderExpression => entity => entity.Period;

    protected override bool IsOrderDescending => true;
}