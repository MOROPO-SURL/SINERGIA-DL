using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;

public record StrategicLineDetailDtoModel(Guid Id, int Index, string Name, PersonBasicDtoModel Coordinator, bool IsEnable, string Objective, StrategicAxeBasicDtoModel? Axe = null, string? Description = null);