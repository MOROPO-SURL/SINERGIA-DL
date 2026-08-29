using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.CQRS.Command.Create;

internal sealed class StrategicProjectIdeaCreateCommandHandler :
    AbstractCreateCommandHandler<StrategicProjectIdea, StrategicProjectIdeaId, Guid, StrategicProjectIdeaCreateCommand, StrategicProjectIdeaDetailDto>,
    IRequestHandler<StrategicProjectIdeaCreateCommand, StrategicProjectIdeaDetailDto>
{
    public StrategicProjectIdeaCreateCommandHandler(IStrategicProjectIdeaCommandRepositoryPort entityCommandRepository, IStrategicProjectIdeaQueryRepositoryPort entityQueryRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}