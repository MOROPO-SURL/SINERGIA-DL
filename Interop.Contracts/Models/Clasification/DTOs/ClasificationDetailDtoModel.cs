namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Clasification.DTOs;

public record ClasificationDetailDtoModel(Guid Id, string Name, int Priority, DateTime CreatedAt, DateTime? UpdatedAt = null, string? Description = null);