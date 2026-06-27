using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;

public record StrategicAxeDetailDtoModel(
    int Id, 
    string Name, 
    bool IsEnable, 
    string Objective,
    MacroprogramBasicDtoModel[] Macroprograms,
    PersonBasicDtoModel? Coordinator = null, 
    string? Description = null);