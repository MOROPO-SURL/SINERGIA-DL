using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Remove;

public record PDLSocialResponsabilityActionRemoveCommand(Guid Id) : IRemoveCommand<Guid>;