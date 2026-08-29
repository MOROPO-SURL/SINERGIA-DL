using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.CQRS.Command.Unarchive;

internal sealed class StrategicProjectKindUnarchiveCommandHandler :
    AbstractUnarchiveCommandHandler<StrategicProjectKind, StrategicProjectKindId, Guid, StrategicProjectKindUnarchiveCommand>,
    IRequestHandler<StrategicProjectKindUnarchiveCommand>
{
    public StrategicProjectKindUnarchiveCommandHandler(IStrategicProjectKindCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}