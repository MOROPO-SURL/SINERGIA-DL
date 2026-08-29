using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.CQRS.Command.Unarchive;

public record PublicPolicyUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;

