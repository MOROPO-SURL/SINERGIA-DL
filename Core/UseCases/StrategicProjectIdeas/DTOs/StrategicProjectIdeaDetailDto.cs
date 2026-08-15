using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.DTOs;

public record StrategicProjectIdeaDetailDto(
    Guid Id, 
    string Title, 
    bool IsEnabled,
    int Priority,
    StrategicProgramBasicDto Program,
    string? Description = null) : IDetailDto;