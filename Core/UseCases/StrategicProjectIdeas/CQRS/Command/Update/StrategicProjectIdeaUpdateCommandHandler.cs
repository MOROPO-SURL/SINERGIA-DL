using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.CQRS.Command.Update;

internal sealed class StrategicProjectIdeaUpdateCommandHandler :
    AbstractUpdateCommandHandler<StrategicProjectIdea, StrategicProjectIdeaId, Guid, StrategicProjectIdeaUpdateCommand, StrategicProjectIdeaDetailDto>,
    IRequestHandler<StrategicProjectIdeaUpdateCommand, StrategicProjectIdeaDetailDto>
{
    public StrategicProjectIdeaUpdateCommandHandler(IStrategicProjectIdeaQueryRepositoryPort entityQueryRepository, IStrategicProjectIdeaCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}