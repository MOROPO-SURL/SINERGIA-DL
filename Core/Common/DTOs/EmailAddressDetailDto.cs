using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;

public record EmailAddressDetailDto(string Value, string? Name = null) : IDetailDto;
