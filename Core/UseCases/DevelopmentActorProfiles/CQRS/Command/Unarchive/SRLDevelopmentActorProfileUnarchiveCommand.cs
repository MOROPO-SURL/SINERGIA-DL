using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Unarchive;

public record SRLDevelopmentActorProfileUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;