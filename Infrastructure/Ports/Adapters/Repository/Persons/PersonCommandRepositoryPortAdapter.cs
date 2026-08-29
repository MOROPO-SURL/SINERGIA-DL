using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Persons;

internal sealed class PersonCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<Person, PersonId, Guid>, IPersonCommandRepositoryPort
{
    public PersonCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<Person> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.OrganizationBrigdes);
    }
}
