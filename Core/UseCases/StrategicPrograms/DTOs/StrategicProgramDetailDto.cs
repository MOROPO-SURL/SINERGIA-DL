using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.DTOs.Clipped;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.DTOs;

public record StrategicProgramDetailDto(
    Guid Id, 
    string Name, 
    StrategicLineBasicDto Line, 
    PersonBasicDto Coordinator, 
    bool IsEnabled, 
    int Priority, 
    string Objective,
    SpecificObjectiveClippedDetailDto[] SpecificObjectives,
    OrganizationBasicDto[] Organizations,
    MacroprogramBasicDto[] Macroprograms,
    ImpactClippedDetailDto[] Impacts,
    ActionClippedDetailDto[] Actions,
    string? Description = null) : IDetailDto;