using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs;

public record EmailAddressDetailDto(string Value, string? Name = null) : IDetailDto;
