using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.CQRS.Query.Detail;

public record UnitMeasurementDetailQuery(Guid Id) : IDetailQuery<UnitMeasurementId, Guid, DTOs.UnitMeasurementDetailDto>;

