using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.CQRS.Command.Create;

public record ClasificationCreateCommand(string Name, int Priority, bool IsEnabled, string? Description = null) : ICreateCommand<ClasificationDetailDto>;