using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.CQRS.Command.Remove;

internal sealed class PersonRemoveCommandHandler :
    AbstractRemoveCommandHandler<Person, PersonId, Guid, PersonRemoveCommand>,
    IRequestHandler<PersonRemoveCommand>
{
    public PersonRemoveCommandHandler(IPersonCommandRepositoryPort entityCommandRepository, IMapper mapper) 
        : base(entityCommandRepository, mapper)
    {
    }
}
