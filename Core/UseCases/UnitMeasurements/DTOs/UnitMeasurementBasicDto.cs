using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.DTOs;

public record UnitMeasurementBasicDto(Guid Id, string Name, string Symbol, bool IsEnabled, bool IsArchived) : IDto;