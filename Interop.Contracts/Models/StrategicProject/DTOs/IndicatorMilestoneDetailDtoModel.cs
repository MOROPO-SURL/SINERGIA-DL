namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;

public record IndicatorMilestoneDetailDtoModel(Guid Id, DateOnly At, float Amount, string? Description = null);
