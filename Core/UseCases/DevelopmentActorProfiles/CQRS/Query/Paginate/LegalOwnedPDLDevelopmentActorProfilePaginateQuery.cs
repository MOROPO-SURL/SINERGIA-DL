using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Paginate;

public record LegalOwnedPDLDevelopmentActorProfilePaginateQuery(int Page, int Limit, Expression<Func<LegalOwnedPDLDevelopmentActorProfile, bool>>? Criteria = null) : IPaginateQuery<LegalOwnedPDLDevelopmentActorProfile, DevelopmentActorProfileId, Guid, DevelopmentActorProfileBasicDto>;