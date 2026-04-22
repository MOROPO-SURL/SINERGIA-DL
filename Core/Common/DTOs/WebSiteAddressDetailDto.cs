using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;

public record WebSiteAddressDetailDto(string Name, string Url) : IDetailDto;