using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs.Clipped;

public record IndicatorChangeClippedDetailDto(DateTime Id, float Amount, string? Context = null) : IDetailDto;
