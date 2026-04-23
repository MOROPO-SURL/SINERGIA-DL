using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.DTOs;

public record KeyVariableBasicDto(Guid Id, string Name, bool IsEnabled, bool IsArchived, string? Alias = null) : IDto;