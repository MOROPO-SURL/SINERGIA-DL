using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Controllers;

[ApiController]
[Route("api/strategicprojects")]
public class StrategicProjectsController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public StrategicProjectsController(ISender mediator, IMapper mapper, ILogger<StrategicProjectsController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<StrategicProjectBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            //PaginateQueryResultModel<StrategiProjectBasicDto> result = await mediator.Send(new StrategiProjectPaginateQuery(sheet, limit));

            //return Ok(mapper.Map<PaginateResultModel<StrategicProjectBasicDtoModel>>(result));
            return Ok(mapper.Map<PaginateResultModel<StrategicProjectBasicDtoModel>>(null!));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<StrategicProjectBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
    {
        try
        {
            //PaginateQueryResultModel<StrategiProjectBasicDto> result = await mediator.Send(new StrategiProjectPaginateQuery(sheet, limit, entity => EF.Functions.ILike(entity.Name, $"%{parameter}%")));

            //return Ok(mapper.Map<PaginateResultModel<StrategicProjectBasicDtoModel>>(result));
            return Ok(mapper.Map<PaginateResultModel<StrategicProjectBasicDtoModel>>(null!));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<StrategicProjectDetailDtoModel>> GetAsync(Guid key)
    {
        try
        {
            //StrategiProjectDetailDto result = await mediator.Send(new StrategiProjectDetailQuery(key));

            //return Ok(mapper.Map<StrategiProjectDetailDtoModel>(result));
            return Ok(mapper.Map<StrategicProjectDetailDtoModel>(null!));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<StrategicProjectDetailDtoModel>> CreateAsync(StrategicProjectCreateRequestModel model)
    {
        try
        {
            //StrategiProjectCreateCommand command = mapper.Map<StrategiProjectCreateCommand>(model);

            //StrategiProjectDetailDto result = await mediator.Send(command);

            //return Ok(mapper.Map<StrategiProjectDetailDtoModel>(result));
            return Ok(mapper.Map<StrategicProjectDetailDtoModel>(null!));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<StrategicProjectDetailDtoModel>> UpdateAsync(StrategicProjectUpdateRequestModel model)
    {
        try
        {
            //StrategiProjectUpdateCommand command = mapper.Map<StrategiProjectUpdateCommand>(model);

            //StrategiProjectDetailDto result = await mediator.Send(command);

            //return Ok(mapper.Map<StrategiProjectDetailDtoModel>(result));
            return Ok(mapper.Map<StrategicProjectDetailDtoModel>(null!));
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
            //await mediator.Send(new StrategiProjectEnableCommand(key));

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
            //await mediator.Send(new StrategiProjectDisableCommand(key));

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
            //await mediator.Send(new StrategiProjectUnarchiveCommand(key));

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
            //await mediator.Send(new StrategiProjectArchiveCommand(key));

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
            //await mediator.Send(new StrategiProjectRemoveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}
