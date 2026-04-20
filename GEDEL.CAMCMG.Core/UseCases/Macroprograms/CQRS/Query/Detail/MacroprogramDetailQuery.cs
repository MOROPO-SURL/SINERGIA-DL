using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Query.Detail;

public record MacroprogramDetailQuery(Guid Id) : IDetailQuery<MacroprogramId, Guid, DTOs.MacroprogramDetailDto>;
