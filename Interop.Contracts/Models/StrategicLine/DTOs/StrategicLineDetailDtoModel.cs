using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;

public record StrategicLineDetailDtoModel(int Id, StrategicAxeBasicDtoModel StrategicAxe, string Name, PersonBasicDtoModel Coordinator, bool IsEnable, string? Description = null);