using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Query.Paginate;

internal sealed class StrategicLinePaginateQueryHandler : 
    AbstractPaginateQueryHandler<StrategicLine, StrategicLineId, Guid, StrategicLinePaginateQuery, StrategicLineBasicDto>,
    IRequestHandler<StrategicLinePaginateQuery, PaginateQueryResultModel<StrategicLineBasicDto>>
{
    public StrategicLinePaginateQueryHandler(IStrategicLineQueryRepositoryPort entityQueryRepository)
        : base(entityQueryRepository)
    {
    }
}