using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.Ports.Repository;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Query.Paginate;

internal sealed class MacroprogramPaginateQueryHandler: AbstractPaginateQueryHandler<Macroprogram, MacroprogramId, Guid, MacroprogramPaginateQuery, MacroprogramBasicDto>,
IRequestHandler<MacroprogramPaginateQuery, PaginateQueryResultModel<MacroprogramBasicDto>>
{
    public MacroprogramPaginateQueryHandler(IMacroprogramQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<Macroprogram, bool>>? GlobalSelector => entity => !entity.IsArchived;

    protected override Expression<Func<Macroprogram, object>> OrderExpression => entity => entity.Index;
}
