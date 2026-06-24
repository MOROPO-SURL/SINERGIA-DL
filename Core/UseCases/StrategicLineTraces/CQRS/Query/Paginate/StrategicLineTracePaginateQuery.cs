using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLineTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLineTraces.CQRS.Query.Paginate;

public record StrategicLineTracePaginateQuery(int Page, int Limit, Expression<Func<StrategicLineTrace, bool>>? Criteria = null) : IPaginateQuery<StrategicLineTrace, TraceId, long, StrategicLineTraceBasicDto>;

