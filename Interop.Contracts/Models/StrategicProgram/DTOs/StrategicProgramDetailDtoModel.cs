using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;

public record StrategicProgramDetailDtoModel(Guid Id, string Name, int Priority, bool IsEnable, StrategicLineDetailDtoModel Line, string? Description = null);