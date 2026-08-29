using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Disable;

public record SRLDevelopmentActorProfileDisableCommand(Guid Id) : IDisableCommand<Guid>;