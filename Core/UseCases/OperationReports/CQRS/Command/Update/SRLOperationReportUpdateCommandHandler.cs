using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.CQRS.Command.Update;

internal sealed class SRLOperationReportUpdateCommandHandler :
    AbstractUpdateCommandHandler<SRLOperationReport, OperationReportId, long, SRLOperationReportUpdateCommand, SRLOperationReportDetailDto>,
    IRequestHandler<SRLOperationReportUpdateCommand, SRLOperationReportDetailDto>
{
    public SRLOperationReportUpdateCommandHandler(ISRLOperationReportCommandRepositoryPort entityCommandRepository, ISRLOperationReportQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}