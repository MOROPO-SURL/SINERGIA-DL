namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;

public record StrategicAxeBasicDtoModel(int Id, string Name)
{
    public override string ToString()
    {
        return $"{Id}. {Name}";
    }
}