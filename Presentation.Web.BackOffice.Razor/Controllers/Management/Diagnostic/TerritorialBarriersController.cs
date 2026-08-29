using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.TerritorialBarriers;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Diagnostic;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/[controller]")]
[Area("diagnostic")]
public class TerritorialBarriersController : AbstractBaseAdministrationArchivableController<
    TerritorialBarrier,
    TerritorialBarrierId,
    Guid,
    TerritorialBarrierBasicViewModel,
    TerritorialBarrierDetailViewModel,
    TerritorialBarrierBasicDto,
    TerritorialBarrierDetailDto,
    TerritorialBarrierPaginateQuery,
    TerritorialBarrierDetailQuery,
    TerritorialBarrierRemoveCommand,
    TerritorialBarrierArchiveCommand,
    TerritorialBarrierUnarchiveCommand>
{
    public TerritorialBarriersController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }
}
