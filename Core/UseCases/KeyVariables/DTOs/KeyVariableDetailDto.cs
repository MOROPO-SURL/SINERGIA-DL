using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.DTOs;

public record KeyVariableDetailDto(Guid Id, string Name, bool IsEnabled, int Priority, string? Alias = null, string? Description = null) : IDetailDto;