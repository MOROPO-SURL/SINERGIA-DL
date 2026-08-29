using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create;

internal sealed class StrategicProgramCreateCommandHandler :
    AbstractCreateCommandHandler<StrategicProgram, StrategicProgramId, Guid, StrategicProgramCreateCommand, StrategicProgramDetailDto>,
    IRequestHandler<StrategicProgramCreateCommand, StrategicProgramDetailDto>
{
    public StrategicProgramCreateCommandHandler(IStrategicProgramCommandRepositoryPort entityCommandRepository, IStrategicProgramQueryRepositoryPort entityQueryRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}