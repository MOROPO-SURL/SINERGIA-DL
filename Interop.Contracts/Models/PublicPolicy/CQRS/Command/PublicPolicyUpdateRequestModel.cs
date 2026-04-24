using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.PublicPolicy.CQRS.Command;

public record PublicPolicyUpdateRequestModel(Guid Id, string Title, PublicPolicyKind Kind, DateTime PublishedAt, string? Description = null);