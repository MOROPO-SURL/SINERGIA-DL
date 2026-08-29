using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.CQRS.Command.Create;

internal sealed class StrategicLineCreateCommandHandler : 
    AbstractCreateCommandHandler<StrategicLine, StrategicLineId, Guid, StrategicLineCreateCommand, StrategicLineDetailDto>,
    IRequestHandler<StrategicLineCreateCommand, StrategicLineDetailDto>
{
    public StrategicLineCreateCommandHandler(IStrategicLineCommandRepositoryPort entityCommandRepository, IStrategicLineQueryRepositoryPort entityQueryRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}