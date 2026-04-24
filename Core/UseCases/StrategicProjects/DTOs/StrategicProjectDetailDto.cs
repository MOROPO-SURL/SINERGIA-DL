using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs;

public record StrategicProjectDetailDto(Guid Id, string Name, int Priority, bool IsEnabled, string? Description = null) : IDetailDto;

