using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Query.Detail;

public record TerritoryPotentialDetailQuery(Guid Id) : IDetailQuery<TerritoryPotentialId, Guid, DTOs.TerritoryPotentialDetailDto>;