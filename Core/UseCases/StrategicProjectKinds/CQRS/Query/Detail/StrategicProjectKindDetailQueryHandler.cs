using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.CQRS.Query.Detail;

internal sealed class StrategicProjectKindDetailQueryHandler :
    AbstractDetailQueryHandler<StrategicProjectKind, StrategicProjectKindId, Guid, StrategicProjectKindDetailQuery, StrategicProjectKindDetailDto>,
    IRequestHandler<StrategicProjectKindDetailQuery, StrategicProjectKindDetailDto>
{
    public StrategicProjectKindDetailQueryHandler(IStrategicProjectKindQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}
