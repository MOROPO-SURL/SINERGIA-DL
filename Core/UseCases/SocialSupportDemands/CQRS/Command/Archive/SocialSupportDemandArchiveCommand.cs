using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Archive;

public record SocialSupportDemandArchiveCommand(Guid Id) : IArchiveCommand<Guid>;