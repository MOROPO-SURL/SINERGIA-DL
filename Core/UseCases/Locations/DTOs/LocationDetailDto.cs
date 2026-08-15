using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Locations.DTOs;

public record LocationDetailDto(Guid Id, string Name, CoordinateValueDto Coordinate, PostalAddressDetailDto PostalAddress, ImageBasicDto? FeatureImage = null, string? Description = null) : IDetailDto;