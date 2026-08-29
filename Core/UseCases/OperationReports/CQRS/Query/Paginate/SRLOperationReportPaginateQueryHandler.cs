using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.CQRS.Query.Paginate;

internal sealed class SRLOperationReportPaginateQueryHandler :
    AbstractPaginateQueryHandler<SRLOperationReport, OperationReportId, long, SRLOperationReportPaginateQuery, SRLOperationReportBasicDto>,
    IRequestHandler<SRLOperationReportPaginateQuery, PaginateQueryResultModel<SRLOperationReportBasicDto>>
{
    public SRLOperationReportPaginateQueryHandler(ISRLOperationReportQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<SRLOperationReport, object>> OrderExpression => entity => entity.Period;

    protected override bool IsOrderDescending => true;
}