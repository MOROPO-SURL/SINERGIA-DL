using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.DTOs;

public record UnitMeasurementDetailDto(Guid Id, string Name, string Symbol, bool Prefixed, bool IsEnabled, int Priority) : IDetailDto;