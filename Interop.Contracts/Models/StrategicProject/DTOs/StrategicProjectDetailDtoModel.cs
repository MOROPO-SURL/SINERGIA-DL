using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;

public record StrategicProjectDetailDtoModel(Guid Id, string Name, int Priority, bool IsEnable, StrategicProgramDetailDtoModel Program, string? Description = null);
