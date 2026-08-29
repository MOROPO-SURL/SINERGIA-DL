using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKindTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKindTraces.CQRS.Query.Paginate;

public record OrganizationKindTracePaginateQuery (int Page, int Limit, Expression<Func<OrganizationKindTrace, bool>>? Criteria = null) : IPaginateQuery<OrganizationKindTrace, TraceId, long, OrganizationKindTraceBasicDto>;
