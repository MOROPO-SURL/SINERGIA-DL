using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Query.Detail;

public record TerritorialBarrierDetailQuery(Guid Id) : IDetailQuery<TerritorialBarrierId, Guid, DTOs.TerritorialBarrierDetailDto>;