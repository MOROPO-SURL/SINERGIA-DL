namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;

public record StrategicProjectDetailDtoModel(Guid Id, string Name, int Priority, bool IsEnable, string? Description = null);
