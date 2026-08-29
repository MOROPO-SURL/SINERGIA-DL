using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.MacroprogramTraces.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.MacroprogramTraces.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.MacroprogramTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.MacroprogramTraces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Security;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/traces/macroprograms")]
[Area("security")]
public class MacroprogramTracesController : AbstractBaseViewingController<
    MacroprogramTrace,
    TraceId,
    long,
    MacroprogramTraceBasicViewModel,
    MacroprogramTraceDetailViewModel,
    MacroprogramTraceBasicDto,
    MacroprogramTraceDetailDto,
    MacroprogramTracePaginateQuery,
    MacroprogramTraceDetailQuery>
{
    public MacroprogramTracesController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }
}
