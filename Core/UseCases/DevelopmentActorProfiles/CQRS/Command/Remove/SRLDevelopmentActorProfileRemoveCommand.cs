using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Remove;

public record SRLDevelopmentActorProfileRemoveCommand(Guid Id) : IRemoveCommand<Guid>;