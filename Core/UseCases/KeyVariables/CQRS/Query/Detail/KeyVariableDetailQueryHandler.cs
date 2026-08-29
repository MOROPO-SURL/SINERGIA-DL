using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Query.Detail;

internal sealed class KeyVariableDetailQueryHandler :
    AbstractDetailQueryHandler<KeyVariable, KeyVariableId, Guid, KeyVariableDetailQuery, KeyVariableDetailDto>,
    IRequestHandler<KeyVariableDetailQuery, KeyVariableDetailDto>
{
    public KeyVariableDetailQueryHandler(IKeyVariableQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}