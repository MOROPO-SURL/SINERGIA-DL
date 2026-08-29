using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Query.List;

internal sealed class TerritoryPotentialListQueryHandler :
    AbstractListQueryHandler<TerritoryPotential, TerritoryPotentialId, Guid, TerritoryPotentialDetailDto, TerritoryPotentialListQuery>,
    IRequestHandler<TerritoryPotentialListQuery, TerritoryPotentialDetailDto[]>
{
    public TerritoryPotentialListQueryHandler(ITerritoryPotentialQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}