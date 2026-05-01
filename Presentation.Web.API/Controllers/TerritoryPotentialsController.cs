using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Query.List;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritoryPotential.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritoryPotential.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/territorypotentials")]
public class TerritoryPotentialsController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public TerritoryPotentialsController(ISender mediator, IMapper mapper, ILogger<TerritoryPotentialsController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<TerritoryPotentialBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<TerritoryPotentialBasicDto> result = await mediator.Send(new TerritoryPotentialPaginateQuery(sheet, limit, entity => !entity.IsArchived));

            return Ok(mapper.Map<PaginateResultModel<TerritoryPotentialBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<TerritoryPotentialBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
    {
        try
        {
            PaginateQueryResultModel<TerritoryPotentialBasicDto> result = await mediator.Send(new TerritoryPotentialPaginateQuery(sheet, limit, entity => !entity.IsArchived && EF.Functions.ILike(entity.Title, $"%{parameter}%")));

            return Ok(mapper.Map<PaginateResultModel<TerritoryPotentialBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet()]
    public async Task<ActionResult<TerritoryPotentialDetailDtoModel[]>> GetAsync()
    {
        try
        {
            TerritoryPotentialDetailDto[] result = await mediator.Send(new TerritoryPotentialListQuery());

            return Ok(mapper.Map<TerritoryPotentialDetailDtoModel[]>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<TerritoryPotentialDetailDtoModel>> GetAsync(Guid key)
    {
        try
        {
            TerritoryPotentialDetailDto result = await mediator.Send(new TerritoryPotentialDetailQuery(key));

            return Ok(mapper.Map<TerritoryPotentialDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<TerritoryPotentialDetailDtoModel>> CreateAsync(TerritoryPotentialCreateRequestModel model)
    {
        try
        {
            TerritoryPotentialCreateCommand command = mapper.Map<TerritoryPotentialCreateCommand>(model);

            TerritoryPotentialDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<TerritoryPotentialDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<TerritoryPotentialDetailDtoModel>> UpdateAsync(TerritoryPotentialUpdateRequestModel model)
    {
        try
        {
            TerritoryPotentialUpdateCommand command = mapper.Map<TerritoryPotentialUpdateCommand>(model);

            TerritoryPotentialDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<TerritoryPotentialDetailDtoModel>(result));
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
            await mediator.Send(new TerritoryPotentialUnarchiveCommand(key));

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
            await mediator.Send(new TerritoryPotentialArchiveCommand(key));

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
            await mediator.Send(new TerritoryPotentialRemoveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}
