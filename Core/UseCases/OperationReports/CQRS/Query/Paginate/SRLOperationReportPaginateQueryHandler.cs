using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.CQRS.Query.Paginate;

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