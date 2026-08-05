using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialResponsabilityAction.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/pdlsocialresponsabilityactions")]
public class PDLSocialResponsabilityActionsController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public PDLSocialResponsabilityActionsController(ISender mediator, IMapper mapper, ILogger<PDLSocialResponsabilityActionsController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<PDLSocialResponsabilityActionBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<PDLSocialResponsabilityActionBasicDto> result = await mediator.Send(new PDLSocialResponsabilityActionPaginateQuery(sheet, limit, entity => !entity.IsArchived));

            return Ok(mapper.Map<PaginateResultModel<PDLSocialResponsabilityActionBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("owner/{key}/page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<PDLSocialResponsabilityActionBasicDtoModel>>> FilterByOwnerAsync(Guid key, int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<PDLSocialResponsabilityActionBasicDto> result = await mediator.Send(new PDLSocialResponsabilityActionPaginateQuery(sheet, limit, entity => !entity.IsArchived && entity.OwnerId == new Domain.Aggretates.DevelopmentActorProfileAggregate.Values.DevelopmentActorProfileId(key)));

            return Ok(mapper.Map<PaginateResultModel<PDLSocialResponsabilityActionBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<PDLSocialResponsabilityActionDetailDtoModel>> GetAsync(Guid key)
    {
        try
        {
            PDLSocialResponsabilityActionDetailDto result = await mediator.Send(new PDLSocialResponsabilityActionDetailQuery(key));

            return Ok(mapper.Map<PDLSocialResponsabilityActionDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<PDLSocialResponsabilityActionDetailDtoModel>> CreateAsync(PDLSocialResponsabilityActionCreateRequestModel model)
    {
        try
        {
            PDLSocialResponsabilityActionCreateCommand command = mapper.Map<PDLSocialResponsabilityActionCreateCommand>(model);

            PDLSocialResponsabilityActionDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<PDLSocialResponsabilityActionDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<PDLSocialResponsabilityActionDetailDtoModel>> UpdateAsync(PDLSocialResponsabilityActionUpdateRequestModel model)
    {
        try
        {
            PDLSocialResponsabilityActionUpdateCommand command = mapper.Map<PDLSocialResponsabilityActionUpdateCommand>(model);

            PDLSocialResponsabilityActionDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<PDLSocialResponsabilityActionDetailDtoModel>(result));
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
            await mediator.Send(new PDLSocialResponsabilityActionUnarchiveCommand(key));

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
            await mediator.Send(new PDLSocialResponsabilityActionArchiveCommand(key));

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
            await mediator.Send(new PDLSocialResponsabilityActionRemoveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}