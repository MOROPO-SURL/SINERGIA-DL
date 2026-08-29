using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Archive;

public record SRLDevelopmentActorProfileArchiveCommand(Guid Id) : IArchiveCommand<Guid>;