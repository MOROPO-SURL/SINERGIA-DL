using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Query.List;

internal sealed class StrategicProgramListQueryHandler :
    AbstractListQueryHandler<StrategicProgram, StrategicProgramId, Guid, StrategicProgramDetailDto, StrategicProgramListQuery>,
    IRequestHandler<StrategicProgramListQuery, StrategicProgramDetailDto[]>
{
    public StrategicProgramListQueryHandler(IStrategicProgramQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}