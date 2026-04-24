using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Command.Unarchive;

public record PublicPolicyUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;

