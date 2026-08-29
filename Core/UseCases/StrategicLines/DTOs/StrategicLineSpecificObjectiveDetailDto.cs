using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.DTOs;

public record StrategicLineSpecificObjectiveDetailDto(Guid Id, int Index, string Content) : IDetailDto;