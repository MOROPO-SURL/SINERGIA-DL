using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;

public record StrategicLineSpecificObjectiveDetailDto(Guid Id, int Index, string Content) : IDetailDto;