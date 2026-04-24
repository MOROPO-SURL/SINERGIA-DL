using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Controllers;

[ApiController]
[Route("api/strategiclines")]
public class StrategicLinesController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public StrategicLinesController(ISender mediator, IMapper mapper, ILogger<StrategicLinesController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<StrategicLineBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            //PaginateQueryResultModel<StrategicLineBasicDto> result = await mediator.Send(new StrategicLinePaginateQuery(sheet, limit));

            //return Ok(mapper.Map<PaginateResultModel<StrategicLineBasicDtoModel>>(result));
            return Ok(mapper.Map<PaginateResultModel<StrategicLineBasicDtoModel>>(null!));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<StrategicLineBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
    {
        try
        {
            //PaginateQueryResultModel<StrategicLineBasicDto> result = await mediator.Send(new StrategicLinePaginateQuery(sheet, limit, entity => EF.Functions.ILike(entity.Name, $"%{parameter}%")));

            //return Ok(mapper.Map<PaginateResultModel<StrategicLineBasicDtoModel>>(result));
            return Ok(mapper.Map<PaginateResultModel<StrategicLineBasicDtoModel>>(null!));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<StrategicLineDetailDtoModel>> GetAsync(Guid key)
    {
        try
        {
            //StrategicLineDetailDto result = await mediator.Send(new StrategicLineDetailQuery(key));

            //return Ok(mapper.Map<StrategicLineDetailDtoModel>(result));
            return Ok(mapper.Map<StrategicLineDetailDtoModel>(null!));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<StrategicLineDetailDtoModel>> CreateAsync(StrategicLineCreateRequestModel model)
    {
        try
        {
            //StrategicLineCreateCommand command = mapper.Map<StrategicLineCreateCommand>(model);

            //StrategicLineDetailDto result = await mediator.Send(command);

            //return Ok(mapper.Map<StrategicLineDetailDtoModel>(result));
            return Ok(mapper.Map<StrategicLineDetailDtoModel>(null!));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<StrategicLineDetailDtoModel>> UpdateAsync(StrategicLineUpdateRequestModel model)
    {
        try
        {
            //StrategicLineUpdateCommand command = mapper.Map<StrategicLineUpdateCommand>(model);

            //StrategicLineDetailDto result = await mediator.Send(command);

            //return Ok(mapper.Map<StrategicLineDetailDtoModel>(result));
            return Ok(mapper.Map<StrategicLineDetailDtoModel>(null!));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPatch("{key}/enable")]
    public async Task<IActionResult> EnableAsync(Guid key)
    {
        try
        {
            //await mediator.Send(new StrategicLineEnableCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPatch("{key}/disable")]
    public async Task<IActionResult> DisableAsync(Guid key)
    {
        try
        {
            //await mediator.Send(new StrategicLineDisableCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPatch("{key}/unarchive")]
    public async Task<IActionResult> UnarchiveAsync(Guid key)
    {
        try
        {
            //await mediator.Send(new StrategicLineUnarchiveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPatch("{key}/archive")]
    public async Task<IActionResult> ArchiveAsync(Guid key)
    {
        try
        {
            //await mediator.Send(new StrategicLineArchiveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpDelete("{key}")]
    public async Task<IActionResult> DeleteAsync(Guid key)
    {
        try
        {
            //await mediator.Send(new StrategicLineRemoveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}