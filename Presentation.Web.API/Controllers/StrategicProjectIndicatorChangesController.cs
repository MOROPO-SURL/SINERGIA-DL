using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Query.List;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Update;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/strategicprojectindicatorchanges")]
public class StrategicProjectIndicatorChangesController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public StrategicProjectIndicatorChangesController(ISender mediator, IMapper mapper, ILogger<StrategicProjectsController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet("by/program/{programId}/indicator/{indicatorId}")]
    public async Task<ActionResult<IndicatorChangeDetailDtoModel[]>> GetByProjectActionIndicatorAsync(Guid programId, Guid indicatorId)
    {
        try
        {
            IndicatorChangeDetailDto[] result = await mediator.Send(new IndicatorChangeListByProjectActionIndicatorQuery(programId, indicatorId));

            return Ok(mapper.Map<IndicatorChangeDetailDtoModel[]>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("lasts/by/program/{programId}")]
    public async Task<ActionResult<IndicatorChangeDetailDtoModel[]>> GetLastsByProjectAsync(Guid programId)
    {
        try
        {
            IndicatorChangeDetailDto[] result = await mediator.Send(new IndicatorChangeListLastsByProjectQuery(programId));

            return Ok(mapper.Map<IndicatorChangeDetailDtoModel[]>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<IndicatorChangeDetailDtoModel>> CreateAsync(IndicatorChangeCreateRequestModel model)
    {
        try
        {
            IndicatorChangeCreateCommand command = mapper.Map<IndicatorChangeCreateCommand>(model);

            IndicatorChangeDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<IndicatorChangeDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<IndicatorChangeDetailDtoModel>> UpdateAsync(IndicatorChangeUpdateRequestModel model)
    {
        try
        {
            IndicatorChangeUpdateCommand command = mapper.Map<IndicatorChangeUpdateCommand>(model);

            IndicatorChangeDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<IndicatorChangeDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}