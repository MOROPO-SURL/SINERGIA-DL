using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;

public record StrategicLineDetailDto(int Id, StrategicAxeBasicDto StrategicAxe, string Name, PersonBasicDto Coordinator, bool IsEnabled, bool IsArchive, string? Description = null) : IDetailDto;