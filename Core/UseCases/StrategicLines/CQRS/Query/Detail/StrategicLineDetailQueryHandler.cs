using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Query.Detail;

internal sealed class StrategicLineDetailQueryHandler : 
    AbstractDetailQueryHandler<StrategicLine, StrategicLineId, Guid, StrategicLineDetailQuery, StrategicLineDetailDto>,
    IRequestHandler<StrategicLineDetailQuery, StrategicLineDetailDto>
{
    public StrategicLineDetailQueryHandler(IStrategicLineQueryRepositoryPort entityQueryRepository, IMapper mapper)
        : base(entityQueryRepository, mapper)
    {
    }
}