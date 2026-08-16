using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs;

public sealed record IndicatorChangeDetailDto(DateTime Id, Guid ProjectId, Guid ActionId, Guid IndicatorId, float Amount, string? Context = null) : IDetailDto;