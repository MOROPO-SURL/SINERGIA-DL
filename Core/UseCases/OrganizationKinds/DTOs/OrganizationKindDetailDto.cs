using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.DTOs;

public record OrganizationKindDetailDto(Guid Id, bool IsEnabled, bool IsArchived, string Name, int Priority, string? Description = null) : IDetailDto;
