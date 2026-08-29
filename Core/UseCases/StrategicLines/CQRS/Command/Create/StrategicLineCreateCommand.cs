using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.CQRS.Command.Create;

public record StrategicLineCreateCommand(
    Guid Id, 
    int Index, 
    string Name, 
    int Priority, 
    bool IsEnabled, 
    string Objective,
    SpecificObjectiveClippedCreateCommand[] SpecificObjectives,
    PublicPolicyBasicDto[] PublicPolicies,
    OrganizationBasicDto[] Organizations,
    MacroprogramBasicDto[] Macroprograms,
    Guid CoordinatorId, 
    int? AxeId = null, 
    string? Description = null) : ICreateCommand<StrategicLineDetailDto>;