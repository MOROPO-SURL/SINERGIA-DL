using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeaTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeaTraces.CQRS.Query.Paginate;

public record StrategicProjectIdeaTracePaginateQuery(int Page, int Limit, Expression<Func<StrategicProjectIdeaTrace, bool>>? Criteria = null) : IPaginateQuery<StrategicProjectIdeaTrace, TraceId, long, StrategicProjectIdeaTraceBasicDto>;