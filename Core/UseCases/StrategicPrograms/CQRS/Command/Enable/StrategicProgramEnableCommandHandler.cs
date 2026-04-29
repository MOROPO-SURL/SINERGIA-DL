using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Enable;

internal sealed class StrategicProgramEnableCommandHandler :
    AbstractEnableCommandHandler<StrategicProgram, StrategicProgramId, Guid, StrategicProgramEnableCommand>,
    IRequest<StrategicProgramEnableCommand>
{
    public StrategicProgramEnableCommandHandler(IStrategicProgramCommandRepositoryPort entityCommandRepository, IStrategicProgramQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}