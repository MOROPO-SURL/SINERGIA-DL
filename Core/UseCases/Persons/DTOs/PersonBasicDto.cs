using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;

public record PersonBasicDto(Guid Id, string Name, bool IsEnabled, bool IsArchived, string? LastName = null, ImageBasicDto? Image = null, string? UserId = null) : IDto;