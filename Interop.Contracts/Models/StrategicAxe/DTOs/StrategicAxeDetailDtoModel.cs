using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;

public record StrategicAxeDetailDtoModel(int Id, string Name, bool IsEnable, string Objective, PersonBasicDtoModel? Coordinator = null, string? Description = null);