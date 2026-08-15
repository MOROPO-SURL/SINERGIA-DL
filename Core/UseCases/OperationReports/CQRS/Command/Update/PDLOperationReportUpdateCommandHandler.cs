using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OperationReports.CQRS.Command.Update;

internal sealed class PDLOperationReportUpdateCommandHandler :
    AbstractUpdateCommandHandler<PDLOperationReport, OperationReportId, long, PDLOperationReportUpdateCommand, PDLOperationReportDetailDto>,
    IRequestHandler<PDLOperationReportUpdateCommand, PDLOperationReportDetailDto>
{
    public PDLOperationReportUpdateCommandHandler(IPDLOperationReportCommandRepositoryPort entityCommandRepository, IPDLOperationReportQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}