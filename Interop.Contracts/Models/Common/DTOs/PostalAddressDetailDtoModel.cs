namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;

public record PostalAddressDetailDtoModel(string Street, string? Number = null, string? Context = null, int? ZipCode = null, string? Name = null);