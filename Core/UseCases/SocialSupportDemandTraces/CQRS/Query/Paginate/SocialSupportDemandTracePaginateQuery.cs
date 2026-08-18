using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemandTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemandTraces.CQRS.Query.Paginate;

public record SocialSupportDemandTracePaginateQuery(int Page, int Limit, Expression<Func<SocialSupportDemandTrace, bool>>? Criteria = null) : IPaginateQuery<SocialSupportDemandTrace, TraceId, long, SocialSupportDemandTraceBasicDto>;