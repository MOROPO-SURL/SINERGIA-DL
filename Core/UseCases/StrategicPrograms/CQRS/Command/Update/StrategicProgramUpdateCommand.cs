using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs.Clipped;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update;

public record StrategicProgramUpdateCommand(
    Guid Id, 
    string Name, 
    int Priority, 
    bool IsEnabled,
    Guid LineId,
    Guid CoordinatorId,
    string Objective,
    SpecificObjectiveClippedCreateCommand[] InSpecificObjectives,
    SpecificObjectiveClippedUpdateCommand[] PatchSpecificObjectives,
    SpecificObjectiveClippedDetailDto[] OutSpecificObjectives,
    ImpactClippedCreateCommand[] InImpacts,
    ImpactClippedUpdateCommand[] PatchImpacts,
    ImpactClippedDetailDto[] OutImpacts,
    ActionClippedCreateCommand[] InActions,
    ActionClippedUpdateCommand[] PatchActions,
    ActionClippedDetailDto[] OutActions,
    OrganizationBasicDto[] InOrganizations,
    OrganizationBasicDto[] OutOrganizations,
    MacroprogramBasicDto[] InMacroprograms,
    MacroprogramBasicDto[] OutMacroprograms,
    string? Description = null) : IUpdateCommand<Guid, StrategicProgramDetailDto>;