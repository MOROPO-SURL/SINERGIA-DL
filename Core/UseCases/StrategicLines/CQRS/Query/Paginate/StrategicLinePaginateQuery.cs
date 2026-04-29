using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Query.Paginate;

public record StrategicLinePaginateQuery(int Page, int Limit, Expression<Func<StrategicLine, bool>>? Criteria = null) : MediatR.IRequest<PaginateQueryResultModel<StrategicLineBasicDto>>;