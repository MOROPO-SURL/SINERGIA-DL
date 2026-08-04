using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.LegalOwnedPDLDevelopmentActorProfiles.CQRS.Query.List;

public record LegalOwnedPDLDevelopmentActorProfileListQuery(Expression<Func<LegalOwnedPDLDevelopmentActorProfile, bool>>? Criteria = null) : IListQuery<LegalOwnedPDLDevelopmentActorProfile, DevelopmentActorProfileId, Guid, LegalOwnedPDLDevelopmentActorProfileDetailDto>;