using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PersonTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.PersonTraces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Security;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/traces/people")]
[Area("security")]
public class PersonTracesController : AbstractBaseViewingController<
    PersonTrace,
    TraceId,
    long,
    PersonTraceBasicViewModel,
    PersonTraceDetailViewModel,
    PersonTraceBasicDto,
    PersonTraceDetailDto,
    PersonTracePaginateQuery,
    PersonTraceDetailQuery>
{
    public PersonTracesController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }
}
