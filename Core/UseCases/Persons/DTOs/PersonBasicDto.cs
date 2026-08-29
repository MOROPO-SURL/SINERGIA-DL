using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.DTOs;

public record PersonBasicDto(Guid Id, string Name, bool IsEnabled, bool IsArchived, string? LastName = null, ImageBasicDto? Image = null, string? UserId = null) : IDto;