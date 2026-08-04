using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.CQRS.Command.Create;

public record PDLModalityCreateCommand(Guid Id, bool IsEnabled, string Name, int Priority, string? Description = null) : ICreateCommand<PDLModalityDetailDto>;