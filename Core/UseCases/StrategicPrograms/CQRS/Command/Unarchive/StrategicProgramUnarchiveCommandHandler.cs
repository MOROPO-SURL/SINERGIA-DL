using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Unarchive;

internal sealed class StrategicProgramUnarchiveCommandHandler :
    AbstractUnarchiveCommandHandler<StrategicProgram, StrategicProgramId, Guid, StrategicProgramUnarchiveCommand>,
    IRequestHandler<StrategicProgramUnarchiveCommand>
{
    public StrategicProgramUnarchiveCommandHandler(IStrategicProgramCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}