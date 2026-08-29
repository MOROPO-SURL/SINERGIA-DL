namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.UnitMeasurement.DTOs;

public record UnitMeasurementDetailDtoModel(Guid Id, string Name, string Symbol, bool Prefixed, bool IsEnabled, int Priority);