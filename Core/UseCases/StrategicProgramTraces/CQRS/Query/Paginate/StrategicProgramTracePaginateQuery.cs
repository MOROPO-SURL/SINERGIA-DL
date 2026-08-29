using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProgramTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProgramTraces.CQRS.Query.Paginate;

public record StrategicProgramTracePaginateQuery(int Page, int Limit, Expression<Func<StrategicProgramTrace, bool>>? Criteria = null) : IPaginateQuery<StrategicProgramTrace, TraceId, long, StrategicProgramTraceBasicDto>;