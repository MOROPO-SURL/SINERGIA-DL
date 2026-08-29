using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivityTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivityTraces.CQRS.Query.Paginate;

public record EconomicActivityTracePaginateQuery(int Page, int Limit, Expression<Func<EconomicActivityTrace, bool>>? Criteria = null) : IPaginateQuery<EconomicActivityTrace, TraceId, long, EconomicActivityTraceBasicDto>;