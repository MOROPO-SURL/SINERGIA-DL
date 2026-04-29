using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.DTOs;

public record ClassificationDetailDto(Guid Id, string Name, bool IsEnabled, bool IsArchived, int Priority, DateTime CreatedAt, DateTime? UpdatedAt = null, string? Description = null) : IDetailDto;