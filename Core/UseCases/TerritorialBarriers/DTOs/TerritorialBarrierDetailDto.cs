using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.DTOs;

public record TerritorialBarrierDetailDto(Guid Id, string Title, bool IsArchived, DateTime CreatedAt, DateTime? UpdatedAt = null, string? Description = null) : IDetailDto;