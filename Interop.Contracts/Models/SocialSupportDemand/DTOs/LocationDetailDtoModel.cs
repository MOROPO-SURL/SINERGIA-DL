using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.DTOs;

public record LocationDetailDtoModel(Guid Id, string Name, CoordinateValueDtoModel Coordinate, PostalAddressDetailDtoModel PostalAddress, ImageBasicDtoModel? FeatureImage = null, string? Description = null);