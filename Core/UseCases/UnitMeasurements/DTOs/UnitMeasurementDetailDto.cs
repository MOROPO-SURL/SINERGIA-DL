using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.DTOs;

public record UnitMeasurementDetailDto(Guid Id, string Name, string Symbol, bool Prefixed, bool IsEnabled, int Priority) : IDetailDto;