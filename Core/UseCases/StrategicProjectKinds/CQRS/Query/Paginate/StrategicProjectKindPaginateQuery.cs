using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.CQRS.Query.Paginate;

public record StrategicProjectKindPaginateQuery(int Page, int Limit, Expression<Func<StrategicProjectKind, bool>>? Criteria = null) : IPaginateQuery<StrategicProjectKind, StrategicProjectKindId, Guid, StrategicProjectKindBasicDto>;