using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Controllers;

[Authorize]
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
    public async Task<ActionResult<PaginateResultModel<StrategicLineBasicDtoModel>>> GetPageAsync(int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<StrategicLineBasicDto> result = await mediator.Send(new StrategicLinePaginateQuery(sheet, limit));

            return Ok(mapper.Map<PaginateResultModel<StrategicLineBasicDtoModel>>(result));
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
            PaginateQueryResultModel<StrategicLineBasicDto> result = await mediator.Send(new StrategicLinePaginateQuery(sheet, limit, entity => EF.Functions.ILike(entity.Name, $"%{parameter}%")));

            return Ok(mapper.Map<PaginateResultModel<StrategicLineBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}/axe/{axeId}")]
    public async Task<ActionResult<StrategicLineDetailDtoModel>> GetAsync(int key, int axeId)
    {
        try
        {
            StrategicLineDetailDto result = await mediator.Send(new StrategicLineDetailQuery(key, axeId));

            return Ok(mapper.Map<StrategicLineDetailDtoModel>(result));
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
            StrategicLineCreateCommand command = mapper.Map<StrategicLineCreateCommand>(model);

            StrategicLineDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<StrategicLineDetailDtoModel>(result));
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
            StrategicLineUpdateCommand command = mapper.Map<StrategicLineUpdateCommand>(model);

            StrategicLineDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<StrategicLineDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPatch("{key}/axe/{axeId}/enable")]
    public async Task<IActionResult> EnableAsync(int key, int axeId)
    {
        try
        {
            await mediator.Send(new StrategicLineEnableCommand(key, axeId));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPatch("{key}/axe/{axeId}/disable")]
    public async Task<IActionResult> DisableAsync(int key, int axeId)
    {
        try
        {
            await mediator.Send(new StrategicLineDisableCommand(key, axeId));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPatch("{key}/axe/{axeId}/unarchive")]
    public async Task<IActionResult> UnarchiveAsync(int key, int axeId)
    {
        try
        {
            await mediator.Send(new StrategicLineUnarchiveCommand(key, axeId));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPatch("{key}/axe/{axeId}/archive")]
    public async Task<IActionResult> ArchiveAsync(int key, int axeId)
    {
        try
        {
            await mediator.Send(new StrategicLineArchiveCommand(key, axeId));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpDelete("{key}/axe/{axeId}")]
    public async Task<IActionResult> DeleteAsync(int key, int axeId)
    {
        try
        {
            await mediator.Send(new StrategicLineRemoveCommand(key, axeId));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}