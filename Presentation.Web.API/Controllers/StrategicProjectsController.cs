using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Query.List;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Controllers;

[Authorize]
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
            PaginateQueryResultModel<StrategicProjectBasicDto> result = await mediator.Send(new StrategicProjectPaginateQuery(sheet, limit, entity => !entity.IsArchived));

            return Ok(mapper.Map<PaginateResultModel<StrategicProjectBasicDtoModel>>(result));
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
            PaginateQueryResultModel<StrategicProjectBasicDto> result = await mediator.Send(new StrategicProjectPaginateQuery(sheet, limit, entity => !entity.IsArchived && EF.Functions.ILike(entity.Name, $"%{parameter}%")));

            return Ok(mapper.Map<PaginateResultModel<StrategicProjectBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [AllowAnonymous]
    [HttpGet()]
    public async Task<ActionResult<StrategicProjectDetailDtoModel[]>> GetAsync()
    {
        try
        {
            StrategicProjectDetailDto[] result = await mediator.Send(new StrategicProjectListQuery());

            return Ok(mapper.Map<StrategicProjectDetailDtoModel[]>(result));
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
            StrategicProjectDetailDto result = await mediator.Send(new StrategicProjectDetailQuery(key));

            return Ok(mapper.Map<StrategicProjectDetailDtoModel>(result));
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
            StrategicProjectCreateCommand command = mapper.Map<StrategicProjectCreateCommand>(model);

            StrategicProjectDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<StrategicProjectDetailDtoModel>(result));
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
            StrategicProjectUpdateCommand command = mapper.Map<StrategicProjectUpdateCommand>(model);

            StrategicProjectDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<StrategicProjectDetailDtoModel>(result));
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
            await mediator.Send(new StrategicProjectEnableCommand(key));

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
            await mediator.Send(new StrategicProjectDisableCommand(key));

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
            await mediator.Send(new StrategicProjectUnarchiveCommand(key));

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
            await mediator.Send(new StrategicProjectArchiveCommand(key));

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
            await mediator.Send(new StrategicProjectRemoveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}
