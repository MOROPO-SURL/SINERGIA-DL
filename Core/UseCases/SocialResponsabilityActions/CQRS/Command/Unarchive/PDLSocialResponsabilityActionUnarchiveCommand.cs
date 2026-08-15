using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Unarchive;

public record PDLSocialResponsabilityActionUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;