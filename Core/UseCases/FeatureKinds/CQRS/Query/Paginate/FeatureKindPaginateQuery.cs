using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureKindAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.CQRS.Query.Paginate;

public record FeatureKindPaginateQuery(int Page, int Limit, Expression<Func<FeatureKind, bool>>? Criteria = null) : IPaginateQuery<FeatureKind, FeatureKindId, Guid, FeatureKindBasicDto>;