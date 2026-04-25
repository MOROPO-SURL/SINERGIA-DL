namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.UnitMeasurement.CQRS.Command;

public record UnitMeasurementCreateRequestModel(string Name, string Symbol, bool Prefixed, int Priority);