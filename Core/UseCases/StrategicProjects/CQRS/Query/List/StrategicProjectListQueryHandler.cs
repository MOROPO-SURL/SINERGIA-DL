using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Query.List;

internal sealed class StrategicProjectListQueryHandler :
    AbstractListQueryHandler<StrategicProject, StrategicProjectId, Guid, StrategicProjectDetailDto, StrategicProjectListQuery>,
    IRequestHandler<StrategicProjectListQuery, StrategicProjectDetailDto[]>
{
    public StrategicProjectListQueryHandler(IStrategicProjectQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}