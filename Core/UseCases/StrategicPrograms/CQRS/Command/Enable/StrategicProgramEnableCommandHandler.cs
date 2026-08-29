using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Enable;

internal sealed class StrategicProgramEnableCommandHandler :
    AbstractEnableCommandHandler<StrategicProgram, StrategicProgramId, Guid, StrategicProgramEnableCommand>,
    IRequest<StrategicProgramEnableCommand>
{
    public StrategicProgramEnableCommandHandler(IStrategicProgramCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}