using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProjectIdea.DTOs;

public record StrategicProjectIdeaBasicDtoModel(Guid Id, string Title, StrategicProgramBasicDtoModel Program, string? Description = null);