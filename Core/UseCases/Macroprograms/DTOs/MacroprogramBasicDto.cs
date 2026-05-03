using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;

public record MacroprogramBasicDto(Guid Id, int Index, string Title, bool IsArchived) : IDto;

