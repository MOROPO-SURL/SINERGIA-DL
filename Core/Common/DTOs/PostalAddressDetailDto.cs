using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;

public record PostalAddressDetailDto(string Street, string? Number = null, string? Context = null, int? ZipCode = null, string? Name = null) : IDetailDto;