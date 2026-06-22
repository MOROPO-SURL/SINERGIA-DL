using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;

public record StrategicLineBasicDtoModel(Guid Id, int Index, string Name, StrategicAxeBasicDtoModel? Axe = null)
{
    public override string ToString()
    {
        if (Axe == null) return $"{Index}. {Name}";

        return $"{Axe.Id}.{Index}. {Name}";
    }
}