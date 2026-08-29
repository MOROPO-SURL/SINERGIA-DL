using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProjectIdea.DTOs;

public record StrategicProjectIdeaDetailDtoModel(Guid Id, string Title, int Priority, bool IsEnable, StrategicProgramBasicDtoModel Program, string Objective, string? Description = null);