using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs.Clipped;

public record ActionIndicatorMilestoneClippedDetailDto(Guid Id, DateOnly At, float Amount, string? Description = null) : IDetailDto;