using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;

public record ObjectiveActionIndicatorChangeDetailDto (DateTime Id, float Amount, string? Context = null) : IDetailDto;

