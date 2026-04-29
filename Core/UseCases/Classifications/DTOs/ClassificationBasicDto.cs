using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Classifications.DTOs;

public record ClassificationBasicDto(Guid Id, string Name, bool IsEnabled, bool IsArchived) : IDto;