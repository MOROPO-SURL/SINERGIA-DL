using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Query.Paginate;

internal sealed class MacroprogramPaginateQueryHandler: AbstractPaginateQueryHandler<Macroprogram, MacroprogramId, Guid, MacroprogramPaginateQuery, MacroprogramBasicDto>,
IRequestHandler<MacroprogramPaginateQuery, PaginateQueryResultModel<MacroprogramBasicDto>>
{
    public MacroprogramPaginateQueryHandler(IMacroprogramQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}
