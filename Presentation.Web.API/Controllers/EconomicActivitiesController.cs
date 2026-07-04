using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivities.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.EconomicActivity.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.EconomicActivity.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/economicactivities")]
public class EconomicActivitiesController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public EconomicActivitiesController(ISender mediator, IMapper mapper, ILogger<EconomicActivitiesController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<EconomicActivityBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<EconomicActivityBasicDto> result = await mediator.Send(new EconomicActivityPaginateQuery(sheet, limit, entity => !entity.IsArchived));

            return Ok(mapper.Map<PaginateResultModel<EconomicActivityBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<EconomicActivityBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
    {
        try
        {
            if (int.TryParse(parameter, out var id))
            {
                PaginateQueryResultModel<EconomicActivityBasicDto> result = await mediator.Send(new EconomicActivityPaginateQuery(
                    sheet,
                    limit,
                    entity => entity.Id == new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(id) || !entity.IsArchived && EF.Functions.ILike(entity.Name, $"%{parameter}%")));

                return Ok(mapper.Map<PaginateResultModel<EconomicActivityBasicDtoModel>>(result));
            }
            else
            {
                PaginateQueryResultModel<EconomicActivityBasicDto> result = await mediator.Send(new EconomicActivityPaginateQuery(
                    sheet,
                    limit,
                    entity => !entity.IsArchived && EF.Functions.ILike(entity.Name, $"%{parameter}%")));

                return Ok(mapper.Map<PaginateResultModel<EconomicActivityBasicDtoModel>>(result));
            }
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<EconomicActivityDetailDtoModel>> GetAsync(int key)
    {
        try
        {
            EconomicActivityDetailDto result = await mediator.Send(new EconomicActivityDetailQuery(key));

            return Ok(mapper.Map<EconomicActivityDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<EconomicActivityDetailDtoModel>> CreateAsync(EconomicActivityCreateRequestModel model)
    {
        try
        {
            EconomicActivityCreateCommand command = mapper.Map<EconomicActivityCreateCommand>(model);

            EconomicActivityDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<EconomicActivityDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<EconomicActivityDetailDtoModel>> UpdateAsync(EconomicActivityUpdateRequestModel model)
    {
        try
        {
            EconomicActivityUpdateCommand command = mapper.Map<EconomicActivityUpdateCommand>(model);

            EconomicActivityDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<EconomicActivityDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPatch("{key}/enable")]
    public async Task<IActionResult> EnableAsync(int key)
    {
        try
        {
            await mediator.Send(new EconomicActivityEnableCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPatch("{key}/disable")]
    public async Task<IActionResult> DisableAsync(int key)
    {
        try
        {
            await mediator.Send(new EconomicActivityDisableCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPatch("{key}/unarchive")]
    public async Task<IActionResult> UnarchiveAsync(int key)
    {
        try
        {
            await mediator.Send(new EconomicActivityUnarchiveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPatch("{key}/archive")]
    public async Task<IActionResult> ArchiveAsync(int key)
    {
        try
        {
            await mediator.Send(new EconomicActivityArchiveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpDelete("{key}")]
    public async Task<IActionResult> DeleteAsync(int key)
    {
        try
        {
            await mediator.Send(new EconomicActivityRemoveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}
