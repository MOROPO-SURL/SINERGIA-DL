using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectTraces.CQRS.Query.Paginate;

public record StrategicProjectTracePaginateQuery(int Page, int Limit, Expression<Func<StrategicProjectTrace, bool>>? Criteria = null) : IPaginateQuery<StrategicProjectTrace, TraceId, long, StrategicProjectTraceBasicDto>;