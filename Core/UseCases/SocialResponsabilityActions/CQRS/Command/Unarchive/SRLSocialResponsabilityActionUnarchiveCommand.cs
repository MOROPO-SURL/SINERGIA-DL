using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Unarchive;

public record SRLSocialResponsabilityActionUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;