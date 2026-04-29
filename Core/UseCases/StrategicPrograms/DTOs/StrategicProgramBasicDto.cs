using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;

public record StrategicProgramBasicDto(Guid Id, string Name, bool IsEnabled, bool IsArchived, string? Description = null) : IDto;