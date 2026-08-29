using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Query.List;

internal sealed class StrategicProgramListQueryHandler :
    AbstractListQueryHandler<StrategicProgram, StrategicProgramId, Guid, StrategicProgramDetailDto, StrategicProgramListQuery>,
    IRequestHandler<StrategicProgramListQuery, StrategicProgramDetailDto[]>
{
    public StrategicProgramListQueryHandler(IStrategicProgramQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}