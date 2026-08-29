using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Query.Paginate;

public record KeyVariablePaginateQuery(int Page, int Limit, Expression<Func<KeyVariable, bool>>? Criteria = null) : IPaginateQuery<KeyVariable, KeyVariableId, Guid, KeyVariableBasicDto>;