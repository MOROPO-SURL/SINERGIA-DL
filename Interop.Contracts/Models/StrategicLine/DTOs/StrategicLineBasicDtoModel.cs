using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;

public record StrategicLineBasicDtoModel(int Id, StrategicAxeBasicDtoModel Axe, string Name);