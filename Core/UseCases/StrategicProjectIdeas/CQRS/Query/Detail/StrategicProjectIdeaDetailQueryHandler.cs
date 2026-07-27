using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectIdeaAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectIdeaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.CQRS.Query.Detail;

internal sealed class StrategicProjectIdeaDetailQueryHandler :
    AbstractDetailQueryHandler<StrategicProjectIdea, StrategicProjectIdeaId, Guid, StrategicProjectIdeaDetailQuery, StrategicProjectIdeaDetailDto>,
    IRequestHandler<StrategicProjectIdeaDetailQuery, StrategicProjectIdeaDetailDto>
{
    public StrategicProjectIdeaDetailQueryHandler(IStrategicProjectIdeaQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}