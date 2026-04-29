using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;

public record StrategicProgramDetailDto(Guid Id, string Name, bool IsEnabled, string? Description = null) : IDetailDto;

