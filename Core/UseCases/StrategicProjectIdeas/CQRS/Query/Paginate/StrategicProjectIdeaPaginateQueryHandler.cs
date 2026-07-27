using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectIdeaAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectIdeaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.CQRS.Query.Paginate;

internal sealed class StrategicProjectIdeaPaginateQueryHandler :
    AbstractPaginateQueryHandler<StrategicProjectIdea, StrategicProjectIdeaId, Guid, StrategicProjectIdeaPaginateQuery, StrategicProjectIdeaBasicDto>,
    IRequestHandler<StrategicProjectIdeaPaginateQuery, PaginateQueryResultModel<StrategicProjectIdeaBasicDto>>
{
    public StrategicProjectIdeaPaginateQueryHandler(IStrategicProjectIdeaQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}