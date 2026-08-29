using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Detail;

public record LegalOwnedPDLDevelopmentActorProfileBasicByOwnerQuery(Guid OwnerId) : MediatR.IRequest<DevelopmentActorProfileBasicDto>;