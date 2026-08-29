using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs;

public record PhoneNumberDetailDto(string Value, string? Name = null) : IDetailDto;
