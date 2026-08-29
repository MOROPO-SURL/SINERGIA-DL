using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.CQRS.Query.Detail;

internal sealed class PersonDetailQueryHandler :
    AbstractDetailQueryHandler<Person, PersonId, Guid, PersonDetailQuery, PersonDetailDto>,
    IRequestHandler<PersonDetailQuery, PersonDetailDto>
{
    public PersonDetailQueryHandler(IPersonQueryRepositoryPort entityQueryRepository, IMapper mapper) : base(entityQueryRepository, mapper)
    {
    }
}