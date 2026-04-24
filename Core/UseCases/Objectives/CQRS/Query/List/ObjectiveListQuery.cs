using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Query.List;

public record ObjectiveListQuery(Expression<Func<Objective, bool>>? Criteria = null) : IListQuery<Objective, ObjectiveId, Guid, ObjectiveDetailDto>;