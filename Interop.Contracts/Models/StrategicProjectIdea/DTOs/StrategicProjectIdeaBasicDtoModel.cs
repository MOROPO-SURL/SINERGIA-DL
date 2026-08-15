using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProjectIdea.DTOs;

public record StrategicProjectIdeaBasicDtoModel(Guid Id, string Title, StrategicProgramBasicDtoModel Program, string? Description = null);