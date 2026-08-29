using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicyTraces.CQRS.Query.List;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicyTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PublicPolicyTrace.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/publicpolicytraces")]
public class PublicPolicyTracesController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public PublicPolicyTracesController(ISender mediator, IMapper mapper, ILogger<PublicPolicyTracesController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet("target/{key}")]
    public async Task<ActionResult<PublicPolicyTraceDetailDtoModel[]>> GetByTargetAsync(Guid key)
    {
        try
        {
            PublicPolicyTraceDetailDto[] result = await mediator.Send(new PublicPolicyTraceListQuery(entity => entity.TargetId!.Value == new PublicPolicyId(key)));

            return Ok(mapper.Map<PublicPolicyTraceDetailDtoModel[]>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}