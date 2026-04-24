using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Query.List;

public record TerritoryPotentialListQuery(Expression<Func<TerritoryPotential, bool>>? Criteria = null) : IListQuery<TerritoryPotential, TerritoryPotentialId, Guid, TerritoryPotentialDetailDto>;