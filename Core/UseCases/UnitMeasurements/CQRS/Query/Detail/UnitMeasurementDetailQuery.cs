using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Query.Detail;

public record UnitMeasurementDetailQuery(Guid Id) : IDetailQuery<UnitMeasurementId, Guid, DTOs.UnitMeasurementDetailDto>;

