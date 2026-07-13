using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.DTOs;

public record OrganizationKindBasicDto(Guid Id, bool IsEnabled, string Name) : IDto;
