using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarrierTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarrierTraces.CQRS.Query.Paginate;

public record TerritorialBarrierTracePaginateQuery(int Page, int Limit, Expression<Func<TerritorialBarrierTrace, bool>>? Criteria = null) : IPaginateQuery<TerritorialBarrierTrace, TraceId, long, TerritorialBarrierTraceBasicDto>;