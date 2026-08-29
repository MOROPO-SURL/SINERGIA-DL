using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PublicPolicy.CQRS.Command;

public record PublicPolicyUpdateRequestModel(Guid Id, string Title, PublicPolicyKind Kind, DateTime PublishedAt, string? Description = null);