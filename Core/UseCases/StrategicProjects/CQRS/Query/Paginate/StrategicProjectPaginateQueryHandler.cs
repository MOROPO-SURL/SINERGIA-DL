using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Query.Paginate;

internal sealed class StrategicProjectPaginateQueryHandler :
    AbstractPaginateQueryHandler<StrategicProject, StrategicProjectId, Guid, StrategicProjectPaginateQuery, StrategicProjectBasicDto>,
    IRequestHandler<StrategicProjectPaginateQuery, PaginateQueryResultModel<StrategicProjectBasicDto>>
{
    public StrategicProjectPaginateQueryHandler(IStrategicProjectQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}