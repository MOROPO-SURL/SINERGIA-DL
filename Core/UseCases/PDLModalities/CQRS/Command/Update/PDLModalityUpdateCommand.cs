using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.CQRS.Command.Update;

public record PDLModalityUpdateCommand(Guid Id, bool IsEnabled, int Priority, string Name, string? Description = null) : IUpdateCommand<Guid, PDLModalityDetailDto>;