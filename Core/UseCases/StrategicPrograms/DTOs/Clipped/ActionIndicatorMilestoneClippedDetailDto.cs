using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.DTOs.Clipped;

public record ActionIndicatorMilestoneClippedDetailDto(Guid Id, DateOnly At, float Amount, string? Description = null) : IDetailDto;