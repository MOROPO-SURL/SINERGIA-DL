using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicLine.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;

public record StrategicProgramDetailDtoModel(
    Guid Id, 
    string Name, 
    int Priority, 
    bool IsEnable, 
    StrategicLineBasicDtoModel Line, 
    PersonBasicDtoModel Coordinator, 
    string Objective,
    SpecificObjectiveDetailDtoModel[] SpecificObjectives,
    ImpactDetailDtoModel[] Impacts,
    ActionDetailDtoModel[] Actions,
    OrganizationBasicDtoModel[] Organizations,
    MacroprogramBasicDtoModel[] Macroprograms,
    string? Description = null);