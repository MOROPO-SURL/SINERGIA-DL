using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.CQRS.Query.List;

internal sealed class StrategicProjectIdeaListQueryHandler :
    AbstractListQueryHandler<StrategicProjectIdea, StrategicProjectIdeaId, Guid, StrategicProjectIdeaDetailDto, StrategicProjectIdeaListQuery>,
    IRequestHandler<StrategicProjectIdeaListQuery, StrategicProjectIdeaDetailDto[]>
{
    public StrategicProjectIdeaListQueryHandler(IStrategicProjectIdeaQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}