using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs.Clipped;

public record SpecificObjectiveProjectClippedDetailDto(Guid Id, int Index, string Content) : IDetailDto;
