using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Clasifications.CQRS.Command.Update;

public record ClasificationUpdateCommand(Guid Id, string Name, int Priority, bool IsEnabled, string? Description = null) : IUpdateCommand<Guid, DTOs.ClasificationDetailDto>;