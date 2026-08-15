using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.CQRS.Query.Detail;

internal sealed class SRLOperationReportDetailQueryHandler :
    AbstractDetailQueryHandler<SRLOperationReport, OperationReportId, long, SRLOperationReportDetailQuery, SRLOperationReportDetailDto>,
    IRequestHandler<SRLOperationReportDetailQuery, SRLOperationReportDetailDto>
{
    public SRLOperationReportDetailQueryHandler(ISRLOperationReportQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}