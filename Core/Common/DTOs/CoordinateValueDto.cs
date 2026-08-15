using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs;

public record CoordinateValueDto(float Latitude, float Longitude) : IDto;