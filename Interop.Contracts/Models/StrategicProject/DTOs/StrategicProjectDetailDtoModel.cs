using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProjectKind.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;

public record StrategicProjectDetailDtoModel(Guid Id, string Name, int Priority, bool IsEnable, StrategicProjectKindBasicDtoModel Kind, StrategicProgramBasicDtoModel Program, string Objective, string? Description = null);