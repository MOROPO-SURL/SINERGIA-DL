using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;

public record PersonBasicDtoModel(Guid Id, string Name, string? LastName = null, ImageBasicDtoModel? Image = null);