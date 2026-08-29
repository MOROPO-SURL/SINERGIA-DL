namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common.DTOs;

public record PostalAddressDetailDtoModel(string Street, string? Number = null, string? Context = null, int? ZipCode = null, string? Name = null);