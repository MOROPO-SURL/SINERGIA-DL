using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKindTraces.CQRS.Query.Detail;

public record OrganizationKindTraceDetailQuery (long Id) : IDetailQuery<TraceId, long, DTOs.OrganizationKindTraceDetailDto>;

