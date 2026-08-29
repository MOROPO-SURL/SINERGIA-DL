using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectIdeaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectIdeas.CQRS.Query.Detail;

public record StrategicProjectIdeaDetailQuery(Guid Id) : IDetailQuery<StrategicProjectIdeaId, Guid, DTOs.StrategicProjectIdeaDetailDto>;