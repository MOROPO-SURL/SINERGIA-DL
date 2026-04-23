using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Query.Paginate;

internal sealed class PersonPaginateQueryHandler :
    AbstractPaginateQueryHandler<Person, PersonId, Guid, PersonPaginateQuery, PersonBasicDto>,
    IRequestHandler<PersonPaginateQuery, PaginateQueryResultModel<PersonBasicDto>>
{
    public PersonPaginateQueryHandler(IPersonQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<Person, bool>>? GlobalSelector => entity => !entity.IsArchived;

    protected override Expression<Func<Person, object>> OrderExpression => entity => entity.Priority;
}