using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using System.Linq.Expressions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.CQRS.Query.Paginate;

public record UnitMeasurementPaginateQuery(int Page, int Limit, Expression<Func<UnitMeasurement, bool>>? Criteria = null) : IPaginateQuery<UnitMeasurement, UnitMeasurementId, Guid, UnitMeasurementBasicDto>;

