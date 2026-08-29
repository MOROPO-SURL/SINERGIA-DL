using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.CQRS.Query.Detail;

public record StrategicProjectKindDetailQuery(Guid Id) : IDetailQuery<StrategicProjectKindId, Guid, DTOs.StrategicProjectKindDetailDto>;