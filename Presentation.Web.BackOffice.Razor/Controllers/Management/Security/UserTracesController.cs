using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UserTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.UserTraces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Security;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/traces/users")]
[Area("security")]
public class UserTracesController : AbstractBaseViewingController<
    UserTrace,
    TraceId,
    long,
    UserTraceBasicViewModel,
    UserTraceDetailViewModel,
    UserTraceBasicDto,
    UserTraceDetailDto,
    UserTracePaginateQuery,
    UserTraceDetailQuery>
{
    public UserTracesController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }
}
