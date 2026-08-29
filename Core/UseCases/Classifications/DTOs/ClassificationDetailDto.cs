using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.DTOs;

public record ClassificationDetailDto(Guid Id, string Name, bool IsEnabled, bool IsArchived, int Priority, DateTime CreatedAt, DateTime? UpdatedAt = null, string? Description = null) : IDetailDto;