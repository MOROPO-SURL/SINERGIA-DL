using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.CQRS.Query.Detail;

internal sealed class StrategicProjectKindDetailQueryHandler :
    AbstractDetailQueryHandler<StrategicProjectKind, StrategicProjectKindId, Guid, StrategicProjectKindDetailQuery, StrategicProjectKindDetailDto>,
    IRequestHandler<StrategicProjectKindDetailQuery, StrategicProjectKindDetailDto>
{
    public StrategicProjectKindDetailQueryHandler(IStrategicProjectKindQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}
