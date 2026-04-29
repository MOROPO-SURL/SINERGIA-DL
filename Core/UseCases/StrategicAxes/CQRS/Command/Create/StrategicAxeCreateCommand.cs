using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Command.Create;

public record StrategicAxeCreateCommand(int Id, string Name, int Priority, bool IsEnabled, string? Description = null) : ICreateCommand<StrategicAxeDetailDto>;