using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;

public sealed record IndicatorChangeDetailDto(DateTime Id, Guid ObjectiveId, Guid ActionId, Guid IndicatorId, float Amount, string? Context = null) : IDetailDto;