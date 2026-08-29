using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.CQRS.Query.Detail;

internal sealed class StrategicLineDetailQueryHandler : 
    AbstractDetailQueryHandler<StrategicLine, StrategicLineId, Guid, StrategicLineDetailQuery, StrategicLineDetailDto>,
    IRequestHandler<StrategicLineDetailQuery, StrategicLineDetailDto>
{
    public StrategicLineDetailQueryHandler(IStrategicLineQueryRepositoryPort entityQueryRepository, IMapper mapper)
        : base(entityQueryRepository, mapper)
    {
    }
}