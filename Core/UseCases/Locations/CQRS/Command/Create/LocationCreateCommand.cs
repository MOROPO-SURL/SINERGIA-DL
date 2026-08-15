using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Locations.CQRS.Command.Create;

public record LocationCreateCommand(Guid Id, string Name, CoordinateValueDto Coordinate, PostalAddressDetailDto PostalAddress, ImageCreateCommand? FeatureImageCreateCommand = null, string? Description = null);