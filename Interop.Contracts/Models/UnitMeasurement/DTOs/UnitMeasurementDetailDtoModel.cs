namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.UnitMeasurement.DTOs;

public record UnitMeasurementDetailDtoModel(Guid Id, string Name, string Symbol, bool Prefixed, bool IsEnabled, int Priority);