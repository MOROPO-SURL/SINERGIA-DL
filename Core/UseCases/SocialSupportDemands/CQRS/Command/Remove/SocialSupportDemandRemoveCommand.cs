using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Remove;

public record SocialSupportDemandRemoveCommand(Guid Id) : IRemoveCommand<Guid>;