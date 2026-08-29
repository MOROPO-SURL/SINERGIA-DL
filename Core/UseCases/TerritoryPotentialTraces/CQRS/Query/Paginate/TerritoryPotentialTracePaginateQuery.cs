using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentialTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentialTraces.CQRS.Query.Paginate;

public record TerritoryPotentialTracePaginateQuery(int Page, int Limit, Expression<Func<TerritoryPotentialTrace, bool>>? Criteria = null) : IPaginateQuery<TerritoryPotentialTrace, TraceId, long, TerritoryPotentialTraceBasicDto>;