using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.CQRS.Query.Detail;

public record MacroprogramDetailQuery(Guid Id) : IDetailQuery<MacroprogramId, Guid, DTOs.MacroprogramDetailDto>;
