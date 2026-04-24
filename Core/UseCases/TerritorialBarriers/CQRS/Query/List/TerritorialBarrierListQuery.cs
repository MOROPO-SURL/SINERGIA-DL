using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Query.List;

public record TerritorialBarrierListQuery(Expression<Func<TerritorialBarrier, bool>>? Criteria = null) : IListQuery<TerritorialBarrier, TerritorialBarrierId, Guid, TerritorialBarrierDetailDto>;