using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Detail;

public record SRLDevelopmentActorProfileBasicByOwnerQuery(Guid OwnerId) : MediatR.IRequest<DevelopmentActorProfileBasicDto>;