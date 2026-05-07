using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.Ports.Repository;

public interface IStrategicLineQueryRepositoryPort
{
    Task<int> CountAsync();

    Task<int> CountAsync(Expression<Func<StrategicLine, bool>> criteria);

    Task<StrategicLine> GetAsync(StrategicLineId id, StrategicAxeId axeId);

    Task<StrategicLine?> FindOneByAsync(Expression<Func<StrategicLine, bool>> criteria);

    IQueryable<StrategicLine> GetAllQueryable();

    IQueryable<StrategicLine> GetFindByQueryable(Expression<Func<StrategicLine, bool>> criteria);

    IQueryable<StrategicLine> GetPageQueryable(int page, int limit, Expression<Func<StrategicLine, bool>>? criteria = null);
}