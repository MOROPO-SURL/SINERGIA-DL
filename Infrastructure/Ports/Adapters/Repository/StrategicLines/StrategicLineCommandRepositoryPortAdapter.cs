using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.StrategicLines;

internal sealed class StrategicLineCommandRepositoryPortAdapter: IStrategicLineCommandRepositoryPort
{
    private readonly DefaultDbContext dbContext;

    public StrategicLineCommandRepositoryPortAdapter(DefaultDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    private DbSet<StrategicLine> DbSet => dbContext.Set<StrategicLine>();

    public async Task AddAsync(StrategicLine entity, bool commit = true)
    {
        await DbSet.AddAsync(entity);

        if (commit) await dbContext.SaveChangesAsync(commit);
    }

    public async Task DeleteAsync(StrategicLine entity, bool commit = true)
    {
        DbSet.Remove(entity);

        if (commit) await dbContext.SaveChangesAsync(commit);
    }

    public void TrackChanges(StrategicLine entity)
    {
        dbContext.Attach(entity);
    }

    public async Task UpdateAsync(StrategicLine entity, bool commit = true)
    {
        DbSet.Update(entity);

        if (commit) await dbContext.SaveChangesAsync(commit);
    }
}