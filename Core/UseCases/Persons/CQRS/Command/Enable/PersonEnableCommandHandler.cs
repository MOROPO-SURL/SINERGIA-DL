using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.CQRS.Command.Enable;

internal sealed class PersonEnableCommandHandler :
    AbstractEnableCommandHandler<Person, PersonId, Guid, PersonEnableCommand>,
    IRequestHandler<PersonEnableCommand>
{
    public PersonEnableCommandHandler(IPersonCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}