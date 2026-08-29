using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.DTOs;

public record UnitMeasurementBasicDto(Guid Id, string Name, string Symbol, bool IsEnabled, bool IsArchived) : IDto;