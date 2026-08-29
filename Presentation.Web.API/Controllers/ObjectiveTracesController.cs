using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ObjectiveTraces.CQRS.Query.List;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ObjectiveTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.ObjectiveTrace.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/objectivetraces")]
public class ObjectiveTracesController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public ObjectiveTracesController(ISender mediator, IMapper mapper, ILogger<ObjectiveTracesController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet("target/{key}")]
    public async Task<ActionResult<ObjectiveTraceDetailDtoModel[]>> GetByTargetAsync(Guid key)
    {
        try
        {
            ObjectiveTraceDetailDto[] result = await mediator.Send(new ObjectiveTraceListQuery(entity => entity.TargetId!.Value == new ObjectiveId(key)));

            return Ok(mapper.Map<ObjectiveTraceDetailDtoModel[]>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}
