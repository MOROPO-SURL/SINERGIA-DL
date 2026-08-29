using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.CQRS.Query.Paginate;

internal sealed class StrategicProjectIdeaPaginateQueryHandler :
    AbstractPaginateQueryHandler<StrategicProjectIdea, StrategicProjectIdeaId, Guid, StrategicProjectIdeaPaginateQuery, StrategicProjectIdeaBasicDto>,
    IRequestHandler<StrategicProjectIdeaPaginateQuery, PaginateQueryResultModel<StrategicProjectIdeaBasicDto>>
{
    public StrategicProjectIdeaPaginateQueryHandler(IStrategicProjectIdeaQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}