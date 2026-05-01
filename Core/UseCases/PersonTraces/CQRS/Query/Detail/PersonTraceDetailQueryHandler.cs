using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PersonTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Query.Detail;

internal sealed class PersonTraceDetailQueryHandler :
    AbstractDetailQueryHandler<PersonTrace, TraceId, long, PersonTraceDetailQuery, PersonTraceDetailDto>,
    IRequestHandler<PersonTraceDetailQuery, PersonTraceDetailDto>
{
    public PersonTraceDetailQueryHandler(IPersonTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}