using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs;

public record PostalAddressDetailDto(string Street, string? Number = null, string? Context = null, int? ZipCode = null, string? Name = null) : IDetailDto;