using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.PublicPolicy.CQRS.Command;

public record PublicPolicyUpdateRequestModel(Guid Id, string Title, string? Description, PublicPolicyKind Kind, DateTime PublisheAt);

