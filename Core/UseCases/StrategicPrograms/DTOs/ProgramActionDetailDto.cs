using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;

public record ProgramActionDetailDto(Guid Id, string Title, int Priority, string? Descrtiption = null) : IDetailDto;