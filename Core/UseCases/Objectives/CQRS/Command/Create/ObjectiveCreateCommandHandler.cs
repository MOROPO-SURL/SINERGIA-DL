using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Create;

internal sealed class ObjectiveCreateCommandHandler :
    AbstractCreateCommandHandler<Objective, ObjectiveId, Guid, ObjectiveCreateCommand, ObjectiveDetailDto>,
    IRequestHandler<ObjectiveCreateCommand, ObjectiveDetailDto>
{
    public ObjectiveCreateCommandHandler(IObjectiveCommandRepositoryPort entityCommandRepository, IObjectiveQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
