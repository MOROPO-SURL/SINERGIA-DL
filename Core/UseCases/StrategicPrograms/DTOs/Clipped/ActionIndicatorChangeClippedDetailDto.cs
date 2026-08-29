using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.DTOs.Clipped;

public record ActionIndicatorChangeClippedDetailDto(DateTime Id, float Amount, string? Context = null) : IDetailDto;