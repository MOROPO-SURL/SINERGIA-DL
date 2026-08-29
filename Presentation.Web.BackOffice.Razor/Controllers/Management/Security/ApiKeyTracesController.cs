using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeyTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.ApiKeyTraces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Security;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/traces/apikeys")]
[Area("security")]
public class ApiKeyTracesController : AbstractBaseViewingController<
    ApiKeyTrace,
    TraceId,
    long,
    ApiKeyTraceBasicViewModel,
    ApiKeyTraceDetailViewModel,
    ApiKeyTraceBasicDto,
    ApiKeyTraceDetailDto,
    ApiKeyTracePaginateQuery,
    ApiKeyTraceDetailQuery>
{
    public ApiKeyTracesController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }
}
