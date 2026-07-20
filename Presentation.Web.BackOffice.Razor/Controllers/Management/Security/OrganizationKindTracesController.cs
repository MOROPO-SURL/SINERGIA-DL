using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKindTraces.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKindTraces.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKindTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.OrganizationKindTraces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Security;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/traces/organizationkinds")]
[Area("security")]
public class OrganizationKindTracesController : AbstractBaseViewingController<
OrganizationKindTrace,
TraceId,
long,
OrganizationKindTraceBasicViewModel,
OrganizationKindTraceDetailViewModel,
OrganizationKindTraceBasicDto,
OrganizationKindTraceDetailDto,
OrganizationKindTracePaginateQuery,
OrganizationKindTraceDetailQuery>
{
    public OrganizationKindTracesController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }
}
