using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.MacroprogramTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.MacroprogramTraces.CQRS.Query.Paginate;

public record MacroprogramTracePaginateQuery(int Page, int Limit, Expression<Func<MacroprogramTrace, bool>>? Criteria = null) : IPaginateQuery<MacroprogramTrace, TraceId, long, MacroprogramTraceBasicDto>;

