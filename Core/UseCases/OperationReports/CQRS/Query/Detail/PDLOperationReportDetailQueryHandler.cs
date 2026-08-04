using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.CQRS.Query.Detail;

internal sealed class PDLOperationReportDetailQueryHandler :
    AbstractDetailQueryHandler<PDLOperationReport, OperationReportId, long, PDLOperationReportDetailQuery, PDLOperationReportDetailDto>,
    IRequestHandler<PDLOperationReportDetailQuery, PDLOperationReportDetailDto>
{
    public PDLOperationReportDetailQueryHandler(IPDLOperationReportQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}