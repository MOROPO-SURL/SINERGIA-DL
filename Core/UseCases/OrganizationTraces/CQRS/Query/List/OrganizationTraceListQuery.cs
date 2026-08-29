using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationTraces.CQRS.Query.List;

public record OrganizationTraceListQuery(Expression<Func<OrganizationTrace, bool>>? Criteria = null) : IListQuery<OrganizationTrace, TraceId, long, OrganizationTraceDetailDto>;