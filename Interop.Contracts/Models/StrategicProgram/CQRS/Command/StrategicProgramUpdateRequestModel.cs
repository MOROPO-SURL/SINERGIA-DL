using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;

public record StrategicProgramUpdateRequestModel(
    Guid Id, 
    string Name, 
    Guid LineId, 
    Guid CoordinatorId, 
    string Objective, 
    int Priority, 
    bool IsEnabled,
    OrganizationBasicDtoModel[] InOrganizations,
    OrganizationBasicDtoModel[] OutOrganizations,
    MacroprogramBasicDtoModel[] InMacroprograms,
    MacroprogramBasicDtoModel[] OutMacroprograms,
    string? Description = null);