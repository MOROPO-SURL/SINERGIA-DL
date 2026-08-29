using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.Ports.Repository;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.CQRS.Query.Paginate;

internal sealed class MacroprogramPaginateQueryHandler: AbstractPaginateQueryHandler<Macroprogram, MacroprogramId, Guid, MacroprogramPaginateQuery, MacroprogramBasicDto>,
IRequestHandler<MacroprogramPaginateQuery, PaginateQueryResultModel<MacroprogramBasicDto>>
{
    public MacroprogramPaginateQueryHandler(IMacroprogramQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<Macroprogram, object>> OrderExpression => entity => entity.Index;
}
