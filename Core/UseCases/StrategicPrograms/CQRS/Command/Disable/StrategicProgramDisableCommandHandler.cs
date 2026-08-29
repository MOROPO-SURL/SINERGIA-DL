using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Disable;

internal sealed class StrategicProgramDisableCommandHandler :
    AbstractDisableCommandHandler<StrategicProgram, StrategicProgramId, Guid, StrategicProgramDisableCommand>,
    IRequestHandler<StrategicProgramDisableCommand>
{
    public StrategicProgramDisableCommandHandler(IStrategicProgramCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}