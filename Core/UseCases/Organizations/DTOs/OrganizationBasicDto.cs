using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;

public record OrganizationBasicDto(Guid Id, string Name, OrganizationKindBasicDto Kind, bool IsEnabled, bool IsArchived, string? Alias = null, ImageBasicDto? Image = null) : IDto;