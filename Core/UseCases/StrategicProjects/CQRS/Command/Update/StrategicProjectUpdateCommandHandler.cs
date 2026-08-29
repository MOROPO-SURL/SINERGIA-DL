using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Update;

internal sealed class StrategicProjectUpdateCommandHandler :
    AbstractUpdateCommandHandler<StrategicProject, StrategicProjectId, Guid, StrategicProjectUpdateCommand, StrategicProjectDetailDto>,
    IRequestHandler<StrategicProjectUpdateCommand, StrategicProjectDetailDto>
{
    public StrategicProjectUpdateCommandHandler(IStrategicProjectQueryRepositoryPort entityQueryRepository, IStrategicProjectCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}