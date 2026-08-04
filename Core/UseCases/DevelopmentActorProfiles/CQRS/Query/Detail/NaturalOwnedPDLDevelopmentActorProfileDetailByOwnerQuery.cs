using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Detail;

public record NaturalOwnedPDLDevelopmentActorProfileDetailByOwnerQuery(Guid OwnerId) : MediatR.IRequest<NaturalOwnedPDLDevelopmentActorProfileDetailDto>;