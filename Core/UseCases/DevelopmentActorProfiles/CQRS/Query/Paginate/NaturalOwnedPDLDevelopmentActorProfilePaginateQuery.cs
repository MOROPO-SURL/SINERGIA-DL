using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Paginate;

public record NaturalOwnedPDLDevelopmentActorProfilePaginateQuery(int Page, int Limit, Expression<Func<NaturalOwnedPDLDevelopmentActorProfile, bool>>? Criteria = null) : IPaginateQuery<NaturalOwnedPDLDevelopmentActorProfile, DevelopmentActorProfileId, Guid, DevelopmentActorProfileBasicDto>;