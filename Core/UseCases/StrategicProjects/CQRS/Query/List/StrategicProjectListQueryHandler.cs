using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Query.List;

internal sealed class StrategicProjectListQueryHandler :
    AbstractListQueryHandler<StrategicProject, StrategicProjectId, Guid, StrategicProjectDetailDto, StrategicProjectListQuery>,
    IRequestHandler<StrategicProjectListQuery, StrategicProjectDetailDto[]>
{
    public StrategicProjectListQueryHandler(IStrategicProjectQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}