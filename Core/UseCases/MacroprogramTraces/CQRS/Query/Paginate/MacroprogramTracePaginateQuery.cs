using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.MacroprogramTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.MacroprogramTraces.CQRS.Query.Paginate;

public record MacroprogramTracePaginateQuery(int Page, int Limit, Expression<Func<MacroprogramTrace, bool>>? Criteria = null) : IPaginateQuery<MacroprogramTrace, TraceId, long, MacroprogramTraceBasicDto>;

