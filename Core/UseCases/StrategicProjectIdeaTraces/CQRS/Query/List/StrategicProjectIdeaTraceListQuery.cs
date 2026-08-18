using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeaTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeaTraces.CQRS.Query.List;

public record StrategicProjectIdeaTraceListQuery(Expression<Func<StrategicProjectIdeaTrace, bool>>? Criteria = null) : IListQuery<StrategicProjectIdeaTrace, TraceId, long, StrategicProjectIdeaTraceDetailDto>;