using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs;

public record WebSiteAddressDetailDto(string Name, string Url) : IDetailDto;