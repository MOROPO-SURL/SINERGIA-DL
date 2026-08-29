using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.Ports.Repository;

public interface ILegalOwnedPDLDevelopmentActorProfileQueryRepositoryPort : IEntityQueryRepositoryPort<LegalOwnedPDLDevelopmentActorProfile, DevelopmentActorProfileId, Guid>
{
}
