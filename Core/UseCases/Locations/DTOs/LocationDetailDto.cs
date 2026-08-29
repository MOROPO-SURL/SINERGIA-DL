using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Locations.DTOs;

public record LocationDetailDto(Guid Id, string Name, CoordinateValueDto Coordinate, PostalAddressDetailDto PostalAddress, ImageBasicDto? FeatureImage = null, string? Description = null) : IDetailDto;