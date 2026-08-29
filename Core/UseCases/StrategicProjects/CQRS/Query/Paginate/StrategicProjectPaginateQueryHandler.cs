using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Query.Paginate;

internal sealed class StrategicProjectPaginateQueryHandler :
    AbstractPaginateQueryHandler<StrategicProject, StrategicProjectId, Guid, StrategicProjectPaginateQuery, StrategicProjectBasicDto>,
    IRequestHandler<StrategicProjectPaginateQuery, PaginateQueryResultModel<StrategicProjectBasicDto>>
{
    public StrategicProjectPaginateQueryHandler(IStrategicProjectQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}