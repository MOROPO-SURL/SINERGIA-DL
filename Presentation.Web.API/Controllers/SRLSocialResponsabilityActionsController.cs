using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.PublicPolicy.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialResponsabilityAction.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/srlsocialresponsabilityactions")]
public class SRLSocialResponsabilityActionsController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public SRLSocialResponsabilityActionsController(ISender mediator, IMapper mapper, ILogger<SRLSocialResponsabilityActionsController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<SRLSocialResponsabilityActionBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<SRLSocialResponsabilityActionBasicDto> result = await mediator.Send(new SRLSocialResponsabilityActionPaginateQuery(sheet, limit, entity => !entity.IsArchived));

            return Ok(mapper.Map<PaginateResultModel<SRLSocialResponsabilityActionBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<SRLSocialResponsabilityActionBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
    {
        try
        {
            PaginateQueryResultModel<SRLSocialResponsabilityActionBasicDto> result = await mediator.Send(new SRLSocialResponsabilityActionPaginateQuery(sheet, limit, entity => !entity.IsArchived && (EF.Functions.ILike(entity.Title, $"%{parameter}%") || EF.Functions.ILike(entity.Owner!.Owner!.Name, $"%{parameter}%"))));

            return Ok(mapper.Map<PaginateResultModel<SRLSocialResponsabilityActionBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("owner/{key}/page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<SRLSocialResponsabilityActionBasicDtoModel>>> FilterByOwnerAsync(Guid key, int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<SRLSocialResponsabilityActionBasicDto> result = await mediator.Send(new SRLSocialResponsabilityActionPaginateQuery(sheet, limit, entity => !entity.IsArchived && entity.OwnerId == new Domain.Aggretates.DevelopmentActorProfileAggregate.Values.DevelopmentActorProfileId(key)));

            return Ok(mapper.Map<PaginateResultModel<SRLSocialResponsabilityActionBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<SRLSocialResponsabilityActionDetailDtoModel>> GetAsync(Guid key)
    {
        try
        {
            SRLSocialResponsabilityActionDetailDto result = await mediator.Send(new SRLSocialResponsabilityActionDetailQuery(key));

            return Ok(mapper.Map<SRLSocialResponsabilityActionDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<SRLSocialResponsabilityActionDetailDtoModel>> CreateAsync(SRLSocialResponsabilityActionCreateRequestModel model)
    {
        try
        {
            SRLSocialResponsabilityActionCreateCommand command = mapper.Map<SRLSocialResponsabilityActionCreateCommand>(model);

            SRLSocialResponsabilityActionDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<SRLSocialResponsabilityActionDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<SRLSocialResponsabilityActionDetailDtoModel>> UpdateAsync(SRLSocialResponsabilityActionUpdateRequestModel model)
    {
        try
        {
            SRLSocialResponsabilityActionUpdateCommand command = mapper.Map<SRLSocialResponsabilityActionUpdateCommand>(model);

            SRLSocialResponsabilityActionDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<SRLSocialResponsabilityActionDetailDtoModel>(result));
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
            await mediator.Send(new SRLSocialResponsabilityActionUnarchiveCommand(key));

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
            await mediator.Send(new SRLSocialResponsabilityActionArchiveCommand(key));

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
            await mediator.Send(new SRLSocialResponsabilityActionRemoveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}