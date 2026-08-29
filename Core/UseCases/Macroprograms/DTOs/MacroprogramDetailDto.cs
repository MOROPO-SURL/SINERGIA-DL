using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;

public record MacroprogramDetailDto(Guid Id, int Index, string Title, DateTime CreatedAt, DateTime? UpdatedAt = null, string? Description = null) : IDetailDto;

