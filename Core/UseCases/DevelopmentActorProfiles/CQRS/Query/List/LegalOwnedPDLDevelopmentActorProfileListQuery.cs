using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.LegalOwnedPDLDevelopmentActorProfiles.CQRS.Query.List;

public record LegalOwnedPDLDevelopmentActorProfileListQuery(Expression<Func<LegalOwnedPDLDevelopmentActorProfile, bool>>? Criteria = null) : IListQuery<LegalOwnedPDLDevelopmentActorProfile, DevelopmentActorProfileId, Guid, LegalOwnedPDLDevelopmentActorProfileDetailDto>;