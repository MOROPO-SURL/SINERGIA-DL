using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.PublicPolicy.DTOs;

public record PublicPolicyDetailDtoModel(Guid Id, string Title, string? Description, PublicPolicyKind Kind, DateTime PublishedAt);