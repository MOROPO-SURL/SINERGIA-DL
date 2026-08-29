using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.DTOs.Clipped;

public record IndicatorChangeClippedDetailDto(DateTime Id, float Amount, string? Context = null) : IDetailDto;
