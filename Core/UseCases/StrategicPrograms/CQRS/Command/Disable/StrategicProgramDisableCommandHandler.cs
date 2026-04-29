using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Disable;

internal sealed class StrategicProgramDisableCommandHandler :
    AbstractDisableCommandHandler<StrategicProgram, StrategicProgramId, Guid, StrategicProgramDisableCommand>,
    IRequestHandler<StrategicProgramDisableCommand>
{
    public StrategicProgramDisableCommandHandler(IStrategicProgramCommandRepositoryPort entityCommandRepository, IStrategicProgramQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}