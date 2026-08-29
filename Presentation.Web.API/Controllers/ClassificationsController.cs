using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Clasification.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Clasification.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/clasifications")]
public class ClassificationsController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public ClassificationsController(ISender mediator, IMapper mapper, ILogger<ClassificationsController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<ClasificationBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<ClassificationBasicDto> result = await mediator.Send(new ClassificationPaginateQuery(sheet, limit, entity => !entity.IsArchived));

            return Ok(mapper.Map<PaginateResultModel<ClasificationBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<ClasificationBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
    {
        try
        {
            PaginateQueryResultModel<ClassificationBasicDto> result = await mediator.Send(new ClassificationPaginateQuery(
                sheet,
                limit,
                entity => !entity.IsArchived && EF.Functions.ILike(entity.Name, $"%{parameter}%")));

            return Ok(mapper.Map<PaginateResultModel<ClasificationBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<ClasificationDetailDtoModel>> GetAsync(Guid key)
    {
        try
        {
            ClassificationDetailDto result = await mediator.Send(new ClassificationDetailQuery(key));

            return Ok(mapper.Map<ClasificationDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<ClasificationDetailDtoModel>> CreateAsync(ClasificationCreateRequestModel model)
    {
        try
        {
            ClassificationCreateCommand command = mapper.Map<ClassificationCreateCommand>(model);

            ClassificationDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<ClasificationDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<ClasificationDetailDtoModel>> UpdateAsync(ClasificationUpdateRequestModel model)
    {
        try
        {
            ClassificationUpdateCommand command = mapper.Map<ClassificationUpdateCommand>(model);

            ClassificationDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<ClasificationDetailDtoModel>(result));
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
            await mediator.Send(new ClassificationEnableCommand(key));

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
            await mediator.Send(new ClassificationDisableCommand(key));

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
            await mediator.Send(new ClassificationUnarchiveCommand(key));

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
            await mediator.Send(new ClassificationArchiveCommand(key));

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
            await mediator.Send(new ClassificationRemoveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}
