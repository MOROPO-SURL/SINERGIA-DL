using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Unarchive;

public record SRLSocialResponsabilityActionUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;