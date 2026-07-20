namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;

public record ActionIndicatorMilestoneDetailDtoModel(Guid Id, DateOnly At, float Amount, string? Description = null);