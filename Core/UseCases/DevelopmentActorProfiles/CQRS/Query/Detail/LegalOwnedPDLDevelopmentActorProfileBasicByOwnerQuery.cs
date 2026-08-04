using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Detail;

public record LegalOwnedPDLDevelopmentActorProfileBasicByOwnerQuery(Guid OwnerId) : MediatR.IRequest<DevelopmentActorProfileBasicDto>;