using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create;

public record StrategicProgramCreateCommand(string Name, int Priority, bool IsEnabled, int LineId, int AxeId, Guid CoordinatorId, string? Description = null) : ICreateCommand<StrategicProgramDetailDto>;