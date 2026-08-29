using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.DTOs.Clipped;

public record SpecificObjectiveProjectClippedDetailDto(Guid Id, int Index, string Content) : IDetailDto;
