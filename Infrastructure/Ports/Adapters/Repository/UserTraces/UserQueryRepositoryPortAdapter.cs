using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UserTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.UserTraces;

internal sealed class UserTraceQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<UserTrace, TraceId, long>, IUserTraceQueryRepositoryPort
{
    public UserTraceQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}