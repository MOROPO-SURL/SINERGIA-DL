using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Command.Remove;

public record PublicPolicyRemoveCommand(Guid Id) : IRemoveCommand<Guid>;

