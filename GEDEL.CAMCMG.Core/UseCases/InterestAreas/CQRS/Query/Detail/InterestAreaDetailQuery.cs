using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.CQRS.Query.Detail;

public record InterestAreaDetailQuery(Guid Id) : IDetailQuery<InterestAreaId, Guid, DTOs.InterestAreaDetailDto>;
