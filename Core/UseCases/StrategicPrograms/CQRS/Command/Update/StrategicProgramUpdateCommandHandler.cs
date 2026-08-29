using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update;

internal sealed class StrategicProgramUpdateCommandHandler :
    AbstractUpdateCommandHandler<StrategicProgram, StrategicProgramId, Guid, StrategicProgramUpdateCommand, StrategicProgramDetailDto>,
    IRequestHandler<StrategicProgramUpdateCommand, StrategicProgramDetailDto>
{
    public StrategicProgramUpdateCommandHandler(IStrategicProgramQueryRepositoryPort entityQueryRepository, IStrategicProgramCommandRepositoryPort entityCommandRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}