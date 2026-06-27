using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Update.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Update;

public record StrategicLineUpdateCommand(
    Guid Id, 
    int Index, 
    string Name, 
    int Priority, 
    bool IsEnabled, 
    Guid CoordinatorId,
    StrategicLineSpecificObjectiveClippedCreateCommand[] InSpecificObjectives,
    StrategicLineSpecificObjectiveClippedUpdateCommand[] PatchSpecificObjectives,
    StrategicLineSpecificObjectiveDetailDto[] OutSpecificObjectives,
    PublicPolicyBasicDto[] InPublicPolicies,
    PublicPolicyBasicDto[] OutPublicPolicies,
    OrganizationBasicDto[] InOrganizations,
    OrganizationBasicDto[] OutOrganizations,
    MacroprogramBasicDto[] InMacroprograms,
    MacroprogramBasicDto[] OutMacroprograms,
    int? AxeId = null, 
    string? Description = null) : IUpdateCommand<Guid, StrategicLineDetailDto>;