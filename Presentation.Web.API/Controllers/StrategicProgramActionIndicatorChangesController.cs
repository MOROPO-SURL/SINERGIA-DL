using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Query.List;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/strategicprogramactionindicatorchanges")]
public class StrategicProgramActionIndicatorChangesController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public StrategicProgramActionIndicatorChangesController(ISender mediator, IMapper mapper, ILogger<StrategicProgramsController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet("by/program/{programId}/action/{actionId}/indicator/{indicatorId}")]
    public async Task<ActionResult<IndicatorChangeDetailDtoModel[]>> GetByProgramActionIndicatorAsync(Guid programId, Guid actionId, Guid indicatorId)
    {
        try
        {
            IndicatorChangeDetailDto[] result = await mediator.Send(new IndicatorChangeListByProgramActionIndicatorQuery(programId, actionId, indicatorId));

            return Ok(mapper.Map<IndicatorChangeDetailDtoModel[]>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("lasts/by/program/{programId}")]
    public async Task<ActionResult<IndicatorChangeDetailDtoModel[]>> GetLastsByProgramAsync(Guid programId)
    {
        try
        {
            IndicatorChangeDetailDto[] result = await mediator.Send(new IndicatorChangeListLastsByProgramQuery(programId));

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