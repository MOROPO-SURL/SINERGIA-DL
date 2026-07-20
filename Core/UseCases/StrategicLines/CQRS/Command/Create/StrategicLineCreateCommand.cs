using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Create;

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