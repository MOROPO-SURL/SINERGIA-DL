using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;

public record StrategicProgramDetailDtoModel(Guid Id, string Name, int Priority, bool IsEnable, StrategicLineBasicDtoModel StrategicLine, PersonBasicDtoModel Coordinator, string? Description = null);