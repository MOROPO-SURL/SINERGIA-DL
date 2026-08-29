using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs;

public record CoordinateValueDto(float Latitude, float Longitude) : IDto;