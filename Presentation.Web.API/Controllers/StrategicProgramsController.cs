using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/strategicprograms")]
public class StrategicProgramsController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public StrategicProgramsController(ISender mediator, IMapper mapper, ILogger<StrategicProgramsController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<StrategicProgramBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            //PaginateQueryResultModel<StrategiProgramBasicDto> result = await mediator.Send(new StrategiProgramPaginateQuery(sheet, limit));

            //return Ok(mapper.Map<PaginateResultModel<StrategicProgramBasicDtoModel>>(result));
            return Ok(mapper.Map<PaginateResultModel<StrategicProgramBasicDtoModel>>(null!));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<StrategicProgramBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
    {
        try
        {
            //PaginateQueryResultModel<StrategiProgramBasicDto> result = await mediator.Send(new StrategiProgramPaginateQuery(sheet, limit, entity => EF.Functions.ILike(entity.Name, $"%{parameter}%")));

            //return Ok(mapper.Map<PaginateResultModel<StrategicProgramBasicDtoModel>>(result));
            return Ok(mapper.Map<PaginateResultModel<StrategicProgramBasicDtoModel>>(null!));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<StrategicProgramDetailDtoModel>> GetAsync(Guid key)
    {
        try
        {
            //StrategiProgramDetailDto result = await mediator.Send(new StrategiProgramDetailQuery(key));

            //return Ok(mapper.Map<StrategiProgramDetailDtoModel>(result));
            return Ok(mapper.Map<StrategicProgramDetailDtoModel>(null!));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<StrategicProgramDetailDtoModel>> CreateAsync(StrategicProgramCreateRequestModel model)
    {
        try
        {
            //StrategiProgramCreateCommand command = mapper.Map<StrategiProgramCreateCommand>(model);

            //StrategiProgramDetailDto result = await mediator.Send(command);

            //return Ok(mapper.Map<StrategiProgramDetailDtoModel>(result));
            return Ok(mapper.Map<StrategicProgramDetailDtoModel>(null!));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<StrategicProgramDetailDtoModel>> UpdateAsync(StrategicProgramUpdateRequestModel model)
    {
        try
        {
            //StrategiProgramUpdateCommand command = mapper.Map<StrategiProgramUpdateCommand>(model);

            //StrategiProgramDetailDto result = await mediator.Send(command);

            //return Ok(mapper.Map<StrategiProgramDetailDtoModel>(result));
            return Ok(mapper.Map<StrategicProgramDetailDtoModel>(null!));
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
            //await mediator.Send(new StrategiProgramEnableCommand(key));

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
            //await mediator.Send(new StrategiProgramDisableCommand(key));

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
            //await mediator.Send(new StrategiProgramUnarchiveCommand(key));

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
            //await mediator.Send(new StrategiProgramArchiveCommand(key));

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
            //await mediator.Send(new StrategiProgramRemoveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}