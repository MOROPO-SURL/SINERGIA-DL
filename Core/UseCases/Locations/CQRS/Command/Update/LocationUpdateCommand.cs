using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Locations.CQRS.Command.Update;

public record LocationUpdateCommand(Guid Id, string Name, CoordinateValueDto Coordinate, PostalAddressDetailDto PostalAddress, ImageCreateCommand? FeatureImageCreateCommand = null, string? Description = null);