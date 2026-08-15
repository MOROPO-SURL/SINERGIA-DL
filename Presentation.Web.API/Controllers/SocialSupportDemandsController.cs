using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Query.List;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.DTOs;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/socialsupportdemands")]
public sealed class SocialSupportDemandsController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public SocialSupportDemandsController(ISender mediator, IMapper mapper, ILogger<SocialSupportDemandsController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<SocialSupportDemandBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<SocialSupportDemandBasicDto> result = await mediator.Send(new SocialSupportDemandPaginateQuery(sheet, limit, entity => !entity.IsArchived));

            return Ok(mapper.Map<PaginateResultModel<SocialSupportDemandBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<SocialSupportDemandBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
    {
        try
        {
            PaginateQueryResultModel<SocialSupportDemandBasicDto> result = await mediator.Send(new SocialSupportDemandPaginateQuery(sheet, limit, entity => !entity.IsArchived && EF.Functions.ILike(entity.Title, $"%{parameter}%")));

            return Ok(mapper.Map<PaginateResultModel<SocialSupportDemandBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("currents/page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<SocialSupportDemandBasicDtoModel>>> GetCurrentsAsync(int sheet, int limit)
    {
        try
        {
            Expression<Func<SocialSupportDemand, bool>> filterExpression = entity => !entity.IsArchived && entity.IsEnabled && ((entity.StartAt <= DateTime.Now && entity.EndAt >= DateTime.Now) || (entity.StartAt == null && entity.EndAt >= DateTime.Now) || (entity.EndAt == null && entity.StartAt <= DateTime.Now) || (entity.StartAt == null && entity.EndAt == null));

            PaginateQueryResultModel<SocialSupportDemandBasicDto> result = await mediator.Send(new SocialSupportDemandPaginateQuery(sheet, limit, filterExpression));

            return Ok(mapper.Map<PaginateResultModel<SocialSupportDemandBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("currents/page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<SocialSupportDemandBasicDtoModel>>> FilterCurrentAsync(int sheet, int limit, string parameter)
    {
        try
        {
            Expression<Func<SocialSupportDemand, bool>> filterExpression = entity => !entity.IsArchived && entity.IsEnabled && ((entity.StartAt <= DateTime.Now && entity.EndAt >= DateTime.Now) || (entity.StartAt == null && entity.EndAt >= DateTime.Now) || (entity.EndAt == null && entity.StartAt <= DateTime.Now) || (entity.StartAt == null && entity.EndAt == null));

            PaginateQueryResultModel<SocialSupportDemandBasicDto> result = await mediator.Send(new SocialSupportDemandPaginateQuery(sheet, limit, filterExpression));

            return Ok(mapper.Map<PaginateResultModel<SocialSupportDemandBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet()]
    public async Task<ActionResult<SocialSupportDemandDetailDtoModel[]>> GetAsync()
    {
        try
        {
            SocialSupportDemandDetailDto[] result = await mediator.Send(new SocialSupportDemandListQuery());

            return Ok(mapper.Map<SocialSupportDemandDetailDtoModel[]>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<SocialSupportDemandDetailDtoModel>> GetAsync(Guid key)
    {
        try
        {
            SocialSupportDemandDetailDto dto = await mediator.Send(new SocialSupportDemandDetailQuery(key));

            SocialSupportDemandDetailDtoModel result = mapper.Map<SocialSupportDemandDetailDtoModel>(dto);

            return Ok(result);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<SocialSupportDemandDetailDtoModel>> CreateAsync(SocialSupportDemandCreateRequestModel model)
    {
        try
        {
            SocialSupportDemandCreateCommand command = mapper.Map<SocialSupportDemandCreateCommand>(model);

            SocialSupportDemandDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<SocialSupportDemandDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<SocialSupportDemandDetailDtoModel>> UpdateAsync(SocialSupportDemandUpdateRequestModel model)
    {
        try
        {
            SocialSupportDemandUpdateCommand command = mapper.Map<SocialSupportDemandUpdateCommand>(model);

            SocialSupportDemandDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<SocialSupportDemandDetailDtoModel>(result));
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
            await mediator.Send(new SocialSupportDemandEnableCommand(key));

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
            await mediator.Send(new SocialSupportDemandDisableCommand(key));

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
            await mediator.Send(new SocialSupportDemandUnarchiveCommand(key));

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
            await mediator.Send(new SocialSupportDemandArchiveCommand(key));

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
            await mediator.Send(new SocialSupportDemandRemoveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}