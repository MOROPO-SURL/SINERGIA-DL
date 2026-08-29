namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicAxe.DTOs;

public record StrategicAxeBasicDtoModel(int Id, string Name)
{
    public override string ToString()
    {
        return $"{Id}. {Name}";
    }
}