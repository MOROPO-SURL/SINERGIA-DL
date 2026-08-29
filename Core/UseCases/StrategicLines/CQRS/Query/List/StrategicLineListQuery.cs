using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.CQRS.Query.List;

public record StrategicLineListQuery(Expression<Func<StrategicLine, bool>>? Criteria = null) : MediatR.IRequest<StrategicLineDetailDto[]>;