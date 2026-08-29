using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.CQRS.Command.Update.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.CQRS.Command.Update;

public record StrategicLineUpdateCommand(
    Guid Id, 
    int Index, 
    string Name, 
    int Priority, 
    bool IsEnabled, 
    Guid CoordinatorId,
    SpecificObjectiveClippedCreateCommand[] InSpecificObjectives,
    SpecificObjectiveClippedUpdateCommand[] PatchSpecificObjectives,
    StrategicLineSpecificObjectiveDetailDto[] OutSpecificObjectives,
    PublicPolicyBasicDto[] InPublicPolicies,
    PublicPolicyBasicDto[] OutPublicPolicies,
    OrganizationBasicDto[] InOrganizations,
    OrganizationBasicDto[] OutOrganizations,
    MacroprogramBasicDto[] InMacroprograms,
    MacroprogramBasicDto[] OutMacroprograms,
    int? AxeId = null, 
    string? Description = null) : IUpdateCommand<Guid, StrategicLineDetailDto>;