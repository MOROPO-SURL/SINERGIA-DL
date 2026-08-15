using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Detail;

public record SRLDevelopmentActorProfileDetailByOwnerQuery(Guid OwnerId) : MediatR.IRequest<SRLDevelopmentActorProfileDetailDto>;