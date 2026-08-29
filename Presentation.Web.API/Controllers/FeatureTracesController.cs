using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureTraces.CQRS.Query.List;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.FeatureTrace.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/featuretraces")]
public class FeatureTracesController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public FeatureTracesController(ISender mediator, IMapper mapper, ILogger<FeatureTracesController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet("target/{key}")]
    public async Task<ActionResult<FeatureTraceDetailDtoModel[]>> GetByTargetAsync(Guid key)
    {
        try
        {
            FeatureTraceDetailDto[] result = await mediator.Send(new FeatureTraceListQuery(entity => entity.TargetId!.Value == new FeatureId(key)));

            return Ok(mapper.Map<FeatureTraceDetailDtoModel[]>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}
