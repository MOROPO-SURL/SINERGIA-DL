using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.DTOs.Clipped;

public record IndicatorMilestoneClippedDetailDto(Guid Id, DateOnly At, float Amount, string? Description = null) : IDetailDto;
