using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.CQRS.Command.Update;

internal sealed class StrategicProjectKindUpdateCommandHandler :
    AbstractUpdateCommandHandler<StrategicProjectKind, StrategicProjectKindId, Guid, StrategicProjectKindUpdateCommand, StrategicProjectKindDetailDto>,
    IRequestHandler<StrategicProjectKindUpdateCommand, StrategicProjectKindDetailDto>
{
    public StrategicProjectKindUpdateCommandHandler(IStrategicProjectKindQueryRepositoryPort entityQueryRepository, IStrategicProjectKindCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}