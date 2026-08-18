using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProgramTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProgramTraces.CQRS.Query.Paginate;

public record StrategicProgramTracePaginateQuery(int Page, int Limit, Expression<Func<StrategicProgramTrace, bool>>? Criteria = null) : IPaginateQuery<StrategicProgramTrace, TraceId, long, StrategicProgramTraceBasicDto>;