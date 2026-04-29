using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create;

internal sealed class StrategicProgramCreateCommandHandler :
    AbstractCreateCommandHandler<StrategicProgram, StrategicProgramId, Guid, StrategicProgramCreateCommand, StrategicProgramDetailDto>,
    IRequestHandler<StrategicProgramCreateCommand, StrategicProgramDetailDto>
{
    public StrategicProgramCreateCommandHandler(IStrategicProgramCommandRepositoryPort entityCommandRepository, IStrategicProgramQueryRepositoryPort entityQueryRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}