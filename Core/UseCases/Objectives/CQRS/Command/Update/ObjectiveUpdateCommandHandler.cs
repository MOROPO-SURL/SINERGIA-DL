using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Update;

internal sealed class ObjectiveUpdateCommandHandler :
    AbstractUpdateCommandHandler<Objective, ObjectiveId, Guid, ObjectiveUpdateCommand, ObjectiveDetailDto>,
    IRequestHandler<ObjectiveUpdateCommand, ObjectiveDetailDto>
{
    public ObjectiveUpdateCommandHandler(IObjectiveCommandRepositoryPort entityCommandRepository, IObjectiveQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
