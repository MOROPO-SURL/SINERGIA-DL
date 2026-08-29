using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.CQRS.Command;

public record LocationCreateRequestModel(Guid Id, string Name, CoordinateValueDtoModel Coordinate, PostalAddressDetailDtoModel PostalAddress, ImageCreateRequestModel? FeatureImageCreateRequest = null, string? Description = null);