using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using System.Linq.Expressions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Query.Paginate;

public record UnitMeasurementPaginateQuery(int Page, int Limit, Expression<Func<UnitMeasurement, bool>>? Criteria = null) : IPaginateQuery<UnitMeasurement, UnitMeasurementId, Guid, UnitMeasurementBasicDto>;

