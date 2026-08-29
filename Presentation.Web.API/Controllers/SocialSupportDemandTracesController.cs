using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemandTraces.CQRS.Query.List;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemandTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialSupportDemandTrace.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/socialsupportdemandtraces")]
public class SocialSupportDemandTracesController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public SocialSupportDemandTracesController(ISender mediator, IMapper mapper, ILogger<SocialSupportDemandTracesController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet("target/{key}")]
    public async Task<ActionResult<SocialSupportDemandTraceDetailDtoModel[]>> GetByTargetAsync(Guid key)
    {
        try
        {
            SocialSupportDemandTraceDetailDto[] result = await mediator.Send(new SocialSupportDemandTraceListQuery(entity => entity.TargetId!.Value == new SocialSupportDemandId(key)));

            return Ok(mapper.Map<SocialSupportDemandTraceDetailDtoModel[]>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}