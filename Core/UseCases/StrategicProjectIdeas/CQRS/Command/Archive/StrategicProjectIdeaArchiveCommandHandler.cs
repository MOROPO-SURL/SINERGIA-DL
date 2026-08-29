using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.CQRS.Command.Archive;

internal sealed class StrategicProjectIdeaArchiveCommandHandler :
    AbstractArchiveCommandHandler<StrategicProjectIdea, StrategicProjectIdeaId, Guid, StrategicProjectIdeaArchiveCommand>,
    IRequestHandler<StrategicProjectIdeaArchiveCommand>
{
    public StrategicProjectIdeaArchiveCommandHandler(IStrategicProjectIdeaCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}