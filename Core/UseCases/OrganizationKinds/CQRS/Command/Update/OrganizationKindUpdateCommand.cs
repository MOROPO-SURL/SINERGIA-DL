using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKinds.CQRS.Command.Update;

public record OrganizationKindUpdateCommand(Guid Id, string Name, bool IsEnabled, int Priority, string? Description = null) : IUpdateCommand<Guid, DTOs.OrganizationKindDetailDto>;