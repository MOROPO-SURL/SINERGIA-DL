using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;

public record ObjectiveBasicDto(Guid Id, int Index, string Title, bool IsEnabled, bool IsArchived, string? Description = null) : IDto;