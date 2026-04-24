using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Command.Create;

public record PublicPolicyCreateCommand(Guid Id, string Title, string? Description, PublicPolicyKind Kind, DateTime PublishedAt) : ICreateCommand<PublicPolicyDetailDto>;

