using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Query.Paginate;

internal sealed class StrategicProgramPaginateQueryHandler :
    AbstractPaginateQueryHandler<StrategicProgram, StrategicProgramId, Guid, StrategicProgramPaginateQuery, StrategicProgramBasicDto>,
    IRequestHandler<StrategicProgramPaginateQuery, PaginateQueryResultModel<StrategicProgramBasicDto>>
{
    public StrategicProgramPaginateQueryHandler(IStrategicProgramQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}