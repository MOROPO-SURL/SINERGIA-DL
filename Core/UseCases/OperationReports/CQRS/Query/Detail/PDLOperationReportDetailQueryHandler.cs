using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OperationReports.CQRS.Query.Detail;

internal sealed class PDLOperationReportDetailQueryHandler :
    AbstractDetailQueryHandler<PDLOperationReport, OperationReportId, long, PDLOperationReportDetailQuery, PDLOperationReportDetailDto>,
    IRequestHandler<PDLOperationReportDetailQuery, PDLOperationReportDetailDto>
{
    public PDLOperationReportDetailQueryHandler(IPDLOperationReportQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}