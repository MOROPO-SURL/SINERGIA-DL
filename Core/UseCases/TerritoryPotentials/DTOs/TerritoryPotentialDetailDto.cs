using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.DTOs;

public record TerritoryPotentialDetailDto(Guid Id, string Title, DateTime CreatedAt, DateTime? UpdatedAt = null, string? Description = null) : IDetailDto;