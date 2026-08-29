using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Query.List;

public record TerritorialBarrierListQuery(Expression<Func<TerritorialBarrier, bool>>? Criteria = null) : IListQuery<TerritorialBarrier, TerritorialBarrierId, Guid, TerritorialBarrierDetailDto>;