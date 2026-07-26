using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.CQRS.Command.Clipped;

public record LocationUpdateClippedRequestModel(Guid Id, string Name, CoordinateValueDtoModel Coordinate, PostalAddressDetailDtoModel PostalAddress, ImageCreateRequestModel? FeatureImageCreateRequest = null, string? Description = null);