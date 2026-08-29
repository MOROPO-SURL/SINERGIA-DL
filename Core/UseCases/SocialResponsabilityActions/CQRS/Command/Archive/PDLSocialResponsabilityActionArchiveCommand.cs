using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Archive;

public record PDLSocialResponsabilityActionArchiveCommand(Guid Id) : IArchiveCommand<Guid>;