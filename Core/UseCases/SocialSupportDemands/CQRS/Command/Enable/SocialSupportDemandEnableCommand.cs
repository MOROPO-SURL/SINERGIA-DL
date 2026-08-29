using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Enable;

public record SocialSupportDemandEnableCommand(Guid Id) : IEnableCommand<Guid>;