using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeaTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeaTraces.CQRS.Query.List;

public record StrategicProjectIdeaTraceListQuery(Expression<Func<StrategicProjectIdeaTrace, bool>>? Criteria = null) : IListQuery<StrategicProjectIdeaTrace, TraceId, long, StrategicProjectIdeaTraceDetailDto>;