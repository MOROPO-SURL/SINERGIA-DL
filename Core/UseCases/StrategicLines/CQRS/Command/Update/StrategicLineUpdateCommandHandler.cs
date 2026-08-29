using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.CQRS.Command.Update;

internal sealed class StrategicLineUpdateCommandHandler : 
    AbstractUpdateCommandHandler<StrategicLine, StrategicLineId, Guid, StrategicLineUpdateCommand, StrategicLineDetailDto>,
    IRequestHandler<StrategicLineUpdateCommand, StrategicLineDetailDto>
{
    public StrategicLineUpdateCommandHandler(IStrategicLineQueryRepositoryPort entityQueryRepository, IStrategicLineCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}