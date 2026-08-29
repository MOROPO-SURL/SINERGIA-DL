using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.KeyVariable.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.KeyVariable.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/keyvariables")]
public class KeyVariablesController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public KeyVariablesController(ISender mediator, IMapper mapper, ILogger<KeyVariablesController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<KeyVariableBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<KeyVariableBasicDto> result = await mediator.Send(new KeyVariablePaginateQuery(sheet, limit, entity => !entity.IsArchived));

            return Ok(mapper.Map<PaginateResultModel<KeyVariableBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<KeyVariableBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
    {
        try
        {
            PaginateQueryResultModel<KeyVariableBasicDto> result = await mediator.Send(new KeyVariablePaginateQuery(
                sheet,
                limit,
                entity => !entity.IsArchived && EF.Functions.ILike(entity.Name, $"%{parameter}%")));

            return Ok(mapper.Map<PaginateResultModel<KeyVariableBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<KeyVariableDetailDtoModel>> GetAsync(Guid key)
    {
        try
        {
            KeyVariableDetailDto result = await mediator.Send(new KeyVariableDetailQuery(key));

            return Ok(mapper.Map<KeyVariableDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<KeyVariableDetailDtoModel>> CreateAsync(KeyVariableCreateRequestModel model)
    {
        try
        {
            KeyVariableCreateCommand command = mapper.Map<KeyVariableCreateCommand>(model);

            KeyVariableDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<KeyVariableDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<KeyVariableDetailDtoModel>> UpdateAsync(KeyVariableUpdateRequestModel model)
    {
        try
        {
            KeyVariableUpdateCommand command = mapper.Map<KeyVariableUpdateCommand>(model);

            KeyVariableDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<KeyVariableDetailDtoModel>(result));
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
            await mediator.Send(new KeyVariableUnarchiveCommand(key));

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
            await mediator.Send(new KeyVariableArchiveCommand(key));

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
            await mediator.Send(new KeyVariableRemoveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}