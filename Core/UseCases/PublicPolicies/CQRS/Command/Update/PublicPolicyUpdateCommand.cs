using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Command.Update;

public record PublicPolicyUpdateCommand(Guid Id, string Title, string? Description, PublicPolicyKind Kind, DateTime PublisheAt) : IUpdateCommand<Guid, DTOs.PublicPolicyDetailDto>;

