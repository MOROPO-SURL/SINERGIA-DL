using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.DTOs;

public record PublicPolicyDetailDto(Guid Id, string Title, bool IsArchived, PublicPolicyKind Kind, DateTime PublishedAt, DateTime CreatedAt, DateTime? UpdatedAt = null, string? Description = null) : IDetailDto;