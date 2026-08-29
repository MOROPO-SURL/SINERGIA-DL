using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PersonTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PersonTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.CQRS.Query.Detail;

internal sealed class PersonTraceDetailQueryHandler :
    AbstractDetailQueryHandler<PersonTrace, TraceId, long, PersonTraceDetailQuery, PersonTraceDetailDto>,
    IRequestHandler<PersonTraceDetailQuery, PersonTraceDetailDto>
{
    public PersonTraceDetailQueryHandler(IPersonTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}