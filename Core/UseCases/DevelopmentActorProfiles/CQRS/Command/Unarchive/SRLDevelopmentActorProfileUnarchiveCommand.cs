using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Unarchive;

public record SRLDevelopmentActorProfileUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;