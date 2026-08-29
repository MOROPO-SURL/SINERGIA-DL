using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.DTOs;

public record StrategicProjectIdeaDetailDto(
    Guid Id, 
    string Title, 
    bool IsEnabled,
    int Priority,
    StrategicProgramBasicDto Program,
    string? Description = null) : IDetailDto;