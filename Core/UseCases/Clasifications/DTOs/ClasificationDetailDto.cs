using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.DTOs;

public record ClasificationDetailDto(Guid Id, string Name, bool IsEnabled, int Priority, DateTime CreatedAt, DateTime? Updated = null, string? Description = null) : IDetailDto;