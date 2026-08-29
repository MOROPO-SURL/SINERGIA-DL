using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.CQRS.Command.Update;

public record PublicPolicyUpdateCommand(Guid Id, string Title, string? Description, PublicPolicyKind Kind, DateTime PublishedAt) : IUpdateCommand<Guid, DTOs.PublicPolicyDetailDto>;