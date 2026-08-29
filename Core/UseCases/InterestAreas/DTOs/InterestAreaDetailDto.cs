using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.DTOs;

public record InterestAreaDetailDto(Guid Id, string Name, bool IsEnabled, string? Description = null) : IDetailDto;