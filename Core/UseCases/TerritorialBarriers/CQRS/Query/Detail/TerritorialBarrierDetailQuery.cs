using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Query.Detail;

public record TerritorialBarrierDetailQuery(Guid Id) : IDetailQuery<TerritorialBarrierId, Guid, DTOs.TerritorialBarrierDetailDto>;