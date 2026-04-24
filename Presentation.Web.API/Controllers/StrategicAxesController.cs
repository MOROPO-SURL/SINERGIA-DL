using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Controllers;

[ApiController]
[Route("api/strategicaxes")]
public class StrategicAxesController: ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public StrategicAxesController(ISender mediator, IMapper mapper, ILogger<StrategicAxesController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<StrategicAxeBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            //PaginateQueryResultModel<UnitMeasurementBasicDto> result = await mediator.Send(new UnitMeasurementPaginateQuery(sheet, limit));

            //return Ok(mapper.Map<PaginateResultModel<StrategicProjectBasicDtoModel>>(result));
            return Ok(mapper.Map<PaginateResultModel<StrategicAxeBasicDtoModel>>(null!));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<StrategicAxeBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
    {
        try
        {
            //PaginateQueryResultModel<UnitMeasurementBasicDto> result = await mediator.Send(new UnitMeasurementPaginateQuery(sheet, limit, entity => EF.Functions.ILike(entity.Name, $"%{parameter}%")));

            //return Ok(mapper.Map<PaginateResultModel<StrategicProjectBasicDtoModel>>(result));
            return Ok(mapper.Map<PaginateResultModel<StrategicAxeBasicDtoModel>>(null!));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<StrategicAxeDetailDtoModel>> GetAsync(Guid key)
    {
        try
        {
            //UnitMeasurementDetailDto result = await mediator.Send(new UnitMeasurementDetailQuery(key));

            //return Ok(mapper.Map<UnitMeasurementDetailDtoModel>(result));
            return Ok(mapper.Map<StrategicAxeDetailDtoModel>(null!));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<StrategicAxeDetailDtoModel>> CreateAsync(StrategicAxeCreateRequestModel model)
    {
        try
        {
            //UnitMeasurementCreateCommand command = mapper.Map<UnitMeasurementCreateCommand>(model);

            //UnitMeasurementDetailDto result = await mediator.Send(command);

            //return Ok(mapper.Map<UnitMeasurementDetailDtoModel>(result));
            return Ok(mapper.Map<StrategicAxeDetailDtoModel>(null!));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<StrategicAxeDetailDtoModel>> UpdateAsync(StrategicAxeUpdateRequestModel model)
    {
        try
        {
            //UnitMeasurementUpdateCommand command = mapper.Map<UnitMeasurementUpdateCommand>(model);

            //UnitMeasurementDetailDto result = await mediator.Send(command);

            //return Ok(mapper.Map<UnitMeasurementDetailDtoModel>(result));
            return Ok(mapper.Map<StrategicAxeDetailDtoModel>(null!));
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
            //await mediator.Send(new UnitMeasurementEnableCommand(key));

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
            //await mediator.Send(new UnitMeasurementDisableCommand(key));

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
            //await mediator.Send(new UnitMeasurementUnarchiveCommand(key));

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
            //await mediator.Send(new UnitMeasurementArchiveCommand(key));

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
            //await mediator.Send(new UnitMeasurementRemoveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}
