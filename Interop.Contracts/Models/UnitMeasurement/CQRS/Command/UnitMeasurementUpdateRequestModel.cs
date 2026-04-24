namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.UnitMeasurement.CQRS.Command;

public record UnitMeasurementUpdateRequestModel(Guid Id, string Name, string Symbol, bool Prefixed);

