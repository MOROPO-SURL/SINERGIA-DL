using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.CQRS.Query.Detail;

internal sealed class StrategicProjectIdeaDetailQueryHandler :
    AbstractDetailQueryHandler<StrategicProjectIdea, StrategicProjectIdeaId, Guid, StrategicProjectIdeaDetailQuery, StrategicProjectIdeaDetailDto>,
    IRequestHandler<StrategicProjectIdeaDetailQuery, StrategicProjectIdeaDetailDto>
{
    public StrategicProjectIdeaDetailQueryHandler(IStrategicProjectIdeaQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}