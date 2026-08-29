using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.DTOs;

public record KeyVariableDetailDto(Guid Id, string Name, bool IsArchived, int Priority, string? Alias = null, string? Description = null) : IDetailDto;