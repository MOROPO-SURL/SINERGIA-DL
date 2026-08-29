using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Disable;

internal sealed class StrategicProjectDisableCommandHandler :
    AbstractDisableCommandHandler<StrategicProject, StrategicProjectId, Guid, StrategicProjectDisableCommand>,
    IRequestHandler<StrategicProjectDisableCommand>
{
    public StrategicProjectDisableCommandHandler(IStrategicProjectCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}