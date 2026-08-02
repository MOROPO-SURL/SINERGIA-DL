using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Archive;

public record SRLSocialResponsabilityActionArchiveCommand(Guid Id) : IArchiveCommand<Guid>;