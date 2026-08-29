using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Query.Detail;

internal sealed class TerritoryPotentialDetailQueryHandler :
    AbstractDetailQueryHandler<TerritoryPotential, TerritoryPotentialId, Guid, TerritoryPotentialDetailQuery, TerritoryPotentialDetailDto>,
    IRequestHandler<TerritoryPotentialDetailQuery, TerritoryPotentialDetailDto>
{
    public TerritoryPotentialDetailQueryHandler(ITerritoryPotentialQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}