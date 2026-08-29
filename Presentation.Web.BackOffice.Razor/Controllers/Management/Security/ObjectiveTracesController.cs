using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ObjectiveTraces.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ObjectiveTraces.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ObjectiveTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.ObjectiveTraces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Security;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/traces/objectives")]
[Area("security")]
public class ObjectiveTracesController : AbstractBaseViewingController<
    ObjectiveTrace,
    TraceId,
    long,
    ObjectiveTraceBasicViewModel,
    ObjectiveTraceDetailViewModel,
    ObjectiveTraceBasicDto,
    ObjectiveTraceDetailDto,
    ObjectiveTracePaginateQuery,
    ObjectiveTraceDetailQuery>
{
    public ObjectiveTracesController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }
}
