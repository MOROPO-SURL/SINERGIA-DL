using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Query.List;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritorialBarrier.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritorialBarrier.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/territorialbarriers")]
public class TerritorialBarriersController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public TerritorialBarriersController(ISender mediator, IMapper mapper, ILogger<TerritorialBarriersController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<TerritorialBarrierBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<TerritorialBarrierBasicDto> result = await mediator.Send(new TerritorialBarrierPaginateQuery(sheet, limit, entity => !entity.IsArchived));

            return Ok(mapper.Map<PaginateResultModel<TerritorialBarrierBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<TerritorialBarrierBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
    {
        try
        {
            PaginateQueryResultModel<TerritorialBarrierBasicDto> result = await mediator.Send(new TerritorialBarrierPaginateQuery(sheet, limit, entity => !entity.IsArchived && EF.Functions.ILike(entity.Title, $"%{parameter}%")));

            return Ok(mapper.Map<PaginateResultModel<TerritorialBarrierBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet()]
    public async Task<ActionResult<TerritorialBarrierDetailDtoModel[]>> GetAsync()
    {
        try
        {
            TerritorialBarrierDetailDto[] result = await mediator.Send(new TerritorialBarrierListQuery());

            return Ok(mapper.Map<TerritorialBarrierDetailDtoModel[]>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<TerritorialBarrierDetailDtoModel>> GetAsync(Guid key)
    {
        try
        {
            TerritorialBarrierDetailDto result = await mediator.Send(new TerritorialBarrierDetailQuery(key));

            return Ok(mapper.Map<TerritorialBarrierDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<TerritorialBarrierDetailDtoModel>> CreateAsync(TerritorialBarrierCreateRequestModel model)
    {
        try
        {
            TerritorialBarrierCreateCommand command = mapper.Map<TerritorialBarrierCreateCommand>(model);

            TerritorialBarrierDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<TerritorialBarrierDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<TerritorialBarrierDetailDtoModel>> UpdateAsync(TerritorialBarrierUpdateRequestModel model)
    {
        try
        {
            TerritorialBarrierUpdateCommand command = mapper.Map<TerritorialBarrierUpdateCommand>(model);

            TerritorialBarrierDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<TerritorialBarrierDetailDtoModel>(result));
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
            await mediator.Send(new TerritorialBarrierUnarchiveCommand(key));

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
            await mediator.Send(new TerritorialBarrierArchiveCommand(key));

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
            await mediator.Send(new TerritorialBarrierRemoveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}
