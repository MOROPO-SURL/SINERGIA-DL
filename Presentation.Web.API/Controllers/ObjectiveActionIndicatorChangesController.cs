using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Query.List;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/objectiveactionindicatorchanges")]
public class ObjectiveActionIndicatorChangesController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public ObjectiveActionIndicatorChangesController(ISender mediator, IMapper mapper, ILogger<ObjectivesController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet("by/objective/{objectiveId}/action/{actionId}/indicator/{indicatorId}")]
    public async Task<ActionResult<IndicatorChangeDetailDtoModel[]>> GetByProgramActionIndicatorAsync(Guid objectiveId, Guid actionId, Guid indicatorId)
    {
        try
        {
            IndicatorChangeDetailDto[] result = await mediator.Send(new IndicatorChangeListByObjectiveActionIndicatorQuery(objectiveId, actionId, indicatorId));

            return Ok(mapper.Map<IndicatorChangeDetailDtoModel[]>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("lasts/by/objective/{objectiveId}")]
    public async Task<ActionResult<IndicatorChangeDetailDtoModel[]>> GetLastsByProgramAsync(Guid objectiveId)
    {
        try
        {
            IndicatorChangeDetailDto[] result = await mediator.Send(new IndicatorChangeListLastsByObjectiveQuery(objectiveId));

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