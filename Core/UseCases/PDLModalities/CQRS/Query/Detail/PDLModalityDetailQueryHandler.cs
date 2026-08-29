using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.Ports;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PDLModalityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PDLModalityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.CQRS.Query.Detail;

internal sealed class PDLModalityDetailQueryHandler :
    AbstractDetailQueryHandler<PDLModality, PDLModalityId, Guid, PDLModalityDetailQuery, PDLModalityDetailDto>,
    IRequestHandler<PDLModalityDetailQuery, PDLModalityDetailDto>
{
    public PDLModalityDetailQueryHandler(IPDLModalityQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}