using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.DTOs;

public record InterestAreaBasicDto(Guid Id, string Name, bool IsEnabled, bool IsArchive, string? Description = null) : IDto;