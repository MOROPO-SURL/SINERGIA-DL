using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PublicPolicy.DTOs;

public record PublicPolicyDetailDtoModel(Guid Id, string Title, string? Description, PublicPolicyKind Kind, DateTime PublishedAt);