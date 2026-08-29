using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Unarchive;

internal sealed class StrategicProjectUnarchiveCommandHandler :
    AbstractUnarchiveCommandHandler<StrategicProject, StrategicProjectId, Guid, StrategicProjectUnarchiveCommand>,
    IRequestHandler<StrategicProjectUnarchiveCommand>
{
    public StrategicProjectUnarchiveCommandHandler(IStrategicProjectCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}