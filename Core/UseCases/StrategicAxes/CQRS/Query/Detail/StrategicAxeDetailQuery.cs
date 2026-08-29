using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.CQRS.Query.Detail;

public record StrategicAxeDetailQuery(int Id) : IDetailQuery<StrategicAxeId, int, DTOs.StrategicAxeDetailDto>;