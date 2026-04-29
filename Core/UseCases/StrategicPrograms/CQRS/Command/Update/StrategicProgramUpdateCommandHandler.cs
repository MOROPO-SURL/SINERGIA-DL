using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update;

internal sealed class StrategicProgramUpdateCommandHandler :
    AbstractUpdateCommandHandler<StrategicProgram, StrategicProgramId, Guid, StrategicProgramUpdateCommand, StrategicProgramDetailDto>,
    IRequestHandler<StrategicProgramUpdateCommand, StrategicProgramDetailDto>
{
    public StrategicProgramUpdateCommandHandler(IStrategicProgramQueryRepositoryPort entityQueryRepository, IStrategicProgramCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}