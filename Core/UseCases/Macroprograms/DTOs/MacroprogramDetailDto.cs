using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;

public record MacroprogramDetailDto(Guid Id, int Index, string Title, DateTime CreatedAt, DateTime? UpdatedAt = null, string? Description = null) : IDetailDto;

