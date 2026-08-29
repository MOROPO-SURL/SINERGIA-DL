using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Unarchive;

public record SocialSupportDemandUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;