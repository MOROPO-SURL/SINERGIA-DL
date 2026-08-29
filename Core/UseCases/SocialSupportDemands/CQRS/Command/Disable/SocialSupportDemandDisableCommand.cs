using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Disable;

public record SocialSupportDemandDisableCommand(Guid Id) : IDisableCommand<Guid>;