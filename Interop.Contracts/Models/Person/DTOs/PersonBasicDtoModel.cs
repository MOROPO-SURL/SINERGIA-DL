using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Person.DTOs;

public record PersonBasicDtoModel(Guid Id, string Name, bool IsEnabled, string? LastName = null, ImageBasicDtoModel? Image = null, string? UserId = null);