using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.DTOs;

public record LocationDetailDtoModel(Guid Id, string Name, CoordinateValueDtoModel Coordinate, PostalAddressDetailDtoModel PostalAddress, ImageBasicDtoModel? FeatureImage = null, string? Description = null);