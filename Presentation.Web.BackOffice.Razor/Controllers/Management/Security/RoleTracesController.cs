using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.RoleTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.RoleTraces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Security;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/traces/roles")]
[Area("security")]
public class RoleTracesController : AbstractBaseViewingController<
    RoleTrace,
    TraceId,
    long,
    RoleTraceBasicViewModel,
    RoleTraceDetailViewModel,
    RoleTraceBasicDto,
    RoleTraceDetailDto,
    RoleTracePaginateQuery,
    RoleTraceDetailQuery>
{
    public RoleTracesController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }
}
