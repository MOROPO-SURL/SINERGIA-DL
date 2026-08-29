using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.CQRS.Command.Unarchive;

internal sealed class StrategicProjectIdeaUnarchiveCommandHandler :
    AbstractUnarchiveCommandHandler<StrategicProjectIdea, StrategicProjectIdeaId, Guid, StrategicProjectIdeaUnarchiveCommand>,
    IRequestHandler<StrategicProjectIdeaUnarchiveCommand>
{
    public StrategicProjectIdeaUnarchiveCommandHandler(IStrategicProjectIdeaCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}