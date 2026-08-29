using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.DTOs;

public record PDLModalityDetailDto(Guid Id, string Name, bool IsEnabled, int Priority, string? Description = null) : IDetailDto;
