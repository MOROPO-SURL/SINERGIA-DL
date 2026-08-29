using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.DTOs;

public record PublicPolicyDetailDto(Guid Id, string Title, bool IsArchived, PublicPolicyKind Kind, DateTime PublishedAt, DateTime CreatedAt, DateTime? UpdatedAt = null, string? Description = null) : IDetailDto;