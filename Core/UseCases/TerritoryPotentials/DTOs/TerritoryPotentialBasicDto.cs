using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.DTOs;

public record TerritoryPotentialBasicDto(Guid Id, string Title, bool IsArchived) : IDto;