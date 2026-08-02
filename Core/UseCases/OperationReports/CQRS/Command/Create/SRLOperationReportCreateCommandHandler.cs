using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.CQRS.Command.Create;

internal sealed class SRLOperationReportCreateCommandHandler :
    AbstractCreateCommandHandler<SRLOperationReport, OperationReportId, long, SRLOperationReportCreateCommand, SRLOperationReportDetailDto>,
    IRequestHandler<SRLOperationReportCreateCommand, SRLOperationReportDetailDto>
{
    public SRLOperationReportCreateCommandHandler(ISRLOperationReportCommandRepositoryPort entityCommandRepository, ISRLOperationReportQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
