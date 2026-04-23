using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Query.Detail;

public record PublicPolicyDetailQuery(Guid Id) : IDetailQuery<PublicPolicyId, Guid, DTOs.PublicPolicyDetailDto>;

