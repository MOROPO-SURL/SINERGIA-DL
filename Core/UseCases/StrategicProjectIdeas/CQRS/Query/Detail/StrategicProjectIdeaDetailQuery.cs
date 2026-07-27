using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectIdeaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectIdeas.CQRS.Query.Detail;

public record StrategicProjectIdeaDetailQuery(Guid Id) : IDetailQuery<StrategicProjectIdeaId, Guid, DTOs.StrategicProjectIdeaDetailDto>;