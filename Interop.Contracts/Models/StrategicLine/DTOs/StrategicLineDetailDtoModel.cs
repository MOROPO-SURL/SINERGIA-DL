namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;

public record StrategicLineDetailDtoModel(Guid Id, string Name, int Priority, bool IsEnable, string? Description = null);