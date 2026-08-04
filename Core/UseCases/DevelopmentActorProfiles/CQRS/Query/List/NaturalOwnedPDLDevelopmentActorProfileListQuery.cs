using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.NaturalOwnedPDLDevelopmentActorProfiles.CQRS.Query.List;

public record NaturalOwnedPDLDevelopmentActorProfileListQuery(Expression<Func<NaturalOwnedPDLDevelopmentActorProfile, bool>>? Criteria = null) : IListQuery<NaturalOwnedPDLDevelopmentActorProfile, DevelopmentActorProfileId, Guid, NaturalOwnedPDLDevelopmentActorProfileDetailDto>;