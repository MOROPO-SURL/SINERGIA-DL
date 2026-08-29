using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Person.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicAxe.DTOs;

public record StrategicAxeDetailDtoModel(
    int Id, 
    string Name, 
    bool IsEnable, 
    string Objective,
    MacroprogramBasicDtoModel[] Macroprograms,
    PersonBasicDtoModel? Coordinator = null, 
    string? Description = null);