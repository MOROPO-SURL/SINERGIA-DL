using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PDLModality.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PDLModality.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/pdlmodalities")]
public class PDLModalitiesController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public PDLModalitiesController(ISender mediator, IMapper mapper, ILogger<PDLModalitiesController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<PDLModalityBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<PDLModalityBasicDto> result = await mediator.Send(new PDLModalityPaginateQuery(sheet, limit));

            return Ok(mapper.Map<PaginateResultModel<PDLModalityBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<PDLModalityBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
    {
        try
        {
            PaginateQueryResultModel<PDLModalityBasicDto> result = await mediator.Send(new PDLModalityPaginateQuery(
                sheet,
                limit,
                entity => EF.Functions.ILike(entity.Name, $"%{parameter}%")));

            return Ok(mapper.Map<PaginateResultModel<PDLModalityBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<PDLModalityDetailDtoModel>> GetAsync(Guid key)
    {
        try
        {
            PDLModalityDetailDto result = await mediator.Send(new PDLModalityDetailQuery(key));

            return Ok(mapper.Map<PDLModalityDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<PDLModalityDetailDtoModel>> CreateAsync(PDLModalityCreateRequestModel model)
    {
        try
        {
            PDLModalityCreateCommand command = mapper.Map<PDLModalityCreateCommand>(model);

            PDLModalityDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<PDLModalityDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<PDLModalityDetailDtoModel>> UpdateAsync(PDLModalityUpdateRequestModel model)
    {
        try
        {
            PDLModalityUpdateCommand command = mapper.Map<PDLModalityUpdateCommand>(model);

            PDLModalityDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<PDLModalityDetailDtoModel>(result));
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
            await mediator.Send(new PDLModalityEnableCommand(key));

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
            await mediator.Send(new PDLModalityDisableCommand(key));

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
            await mediator.Send(new PDLModalityRemoveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}
