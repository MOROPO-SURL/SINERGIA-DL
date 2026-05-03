using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;

public record StrategicLineDetailDtoModel(int Id, StrategicAxeBasicDtoModel Axe, string Name, int Priority, bool IsEnable, string? Description = null);