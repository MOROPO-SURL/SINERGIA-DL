using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.DTOs;

public record TerritoryPotentialDetailDto(Guid Id, string Title, DateTime CreatedAt, DateTime? UpdatedAt = null, string? Description = null) : IDetailDto;