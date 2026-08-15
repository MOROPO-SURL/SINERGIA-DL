using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectIdeaAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectIdeaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.CQRS.Query.List;

internal sealed class StrategicProjectIdeaListQueryHandler :
    AbstractListQueryHandler<StrategicProjectIdea, StrategicProjectIdeaId, Guid, StrategicProjectIdeaDetailDto, StrategicProjectIdeaListQuery>,
    IRequestHandler<StrategicProjectIdeaListQuery, StrategicProjectIdeaDetailDto[]>
{
    public StrategicProjectIdeaListQueryHandler(IStrategicProjectIdeaQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}