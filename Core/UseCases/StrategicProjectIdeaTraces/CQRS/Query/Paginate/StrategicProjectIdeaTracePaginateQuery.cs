using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeaTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeaTraces.CQRS.Query.Paginate;

public record StrategicProjectIdeaTracePaginateQuery(int Page, int Limit, Expression<Func<StrategicProjectIdeaTrace, bool>>? Criteria = null) : IPaginateQuery<StrategicProjectIdeaTrace, TraceId, long, StrategicProjectIdeaTraceBasicDto>;