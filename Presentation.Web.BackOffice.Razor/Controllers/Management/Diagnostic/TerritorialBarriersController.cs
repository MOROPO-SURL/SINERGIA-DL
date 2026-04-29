using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.TerritorialBarriers;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Diagnostic;

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
