using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;

public record ProgramProjectIdeaDetailDto(Guid Id, string Name, bool IsArchive, bool IsEnabled, int Priority, string? Description = null) : IDetailDto;