using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Unarchive;

public record SocialSupportDemandUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;