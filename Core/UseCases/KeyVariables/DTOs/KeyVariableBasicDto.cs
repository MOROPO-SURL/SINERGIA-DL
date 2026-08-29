using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.DTOs;

public record KeyVariableBasicDto(Guid Id, string Name, bool IsArchived, string? Alias = null) : IDto;