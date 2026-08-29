namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.UnitMeasurement.CQRS.Command;

public record UnitMeasurementUpdateRequestModel(Guid Id, string Name, string Symbol, bool Prefixed, int Priority);