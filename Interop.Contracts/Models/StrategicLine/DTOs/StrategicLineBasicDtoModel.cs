using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;

public record StrategicLineBasicDtoModel(int Id, StrategicAxeBasicDtoModel StrategicAxe, string Name)
{
    public override string ToString()
    {
        return $"{StrategicAxe.Id}.{Id}. {Name}";
    }
}