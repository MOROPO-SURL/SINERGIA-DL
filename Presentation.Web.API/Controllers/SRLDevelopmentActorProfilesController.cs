using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SRLDevelopmentActorProfiles.CQRS.Query.List;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/srldevelopmentactorprofiles")]
public class SRLDevelopmentActorProfilesController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public SRLDevelopmentActorProfilesController(ISender mediator, IMapper mapper, ILogger<SRLDevelopmentActorProfilesController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<DevelopmentActorProfileBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<DevelopmentActorProfileBasicDto> result = await mediator.Send(new SRLDevelopmentActorProfilePaginateQuery(sheet, limit, entity => !entity.IsArchived));

            return Ok(mapper.Map<PaginateResultModel<DevelopmentActorProfileBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<DevelopmentActorProfileBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
    {
        try
        {
            PaginateQueryResultModel<DevelopmentActorProfileBasicDto> result = await mediator.Send(new SRLDevelopmentActorProfilePaginateQuery(
                sheet,
                limit,
                entity => !entity.IsArchived && EF.Functions.ILike(entity.Owner!.Name, $"%{parameter}%")));

            return Ok(mapper.Map<PaginateResultModel<DevelopmentActorProfileBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    public async Task<ActionResult<SRLDevelopmentActorProfileDetailDtoModel[]>> GetAsync()
    {
        try
        {
            SRLDevelopmentActorProfileDetailDto[] result = await mediator.Send(new SRLDevelopmentActorProfileListQuery());

            return Ok(mapper.Map<SRLDevelopmentActorProfileDetailDtoModel[]>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<SRLDevelopmentActorProfileDetailDtoModel>> GetAsync(Guid key)
    {
        try
        {
            SRLDevelopmentActorProfileDetailDto result = await mediator.Send(new SRLDevelopmentActorProfileDetailQuery(key));

            SRLDevelopmentActorProfileDetailDtoModel model = mapper.Map<SRLDevelopmentActorProfileDetailDtoModel>(result);

            return Ok(model);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("by/owner/{key}")]
    public async Task<ActionResult<SRLDevelopmentActorProfileDetailDtoModel>> GetBasicByOwnerAsync(Guid key)
    {
        try
        {
            DevelopmentActorProfileBasicDto result = await mediator.Send(new SRLDevelopmentActorProfileBasicByOwnerQuery(key));

            DevelopmentActorProfileBasicDtoModel model = mapper.Map<DevelopmentActorProfileBasicDtoModel>(result);

            return Ok(model);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("by/owner/{key}/detail")]
    public async Task<ActionResult<SRLDevelopmentActorProfileDetailDtoModel>> GetDetailByOwnerAsync(Guid key)
    {
        try
        {
            SRLDevelopmentActorProfileDetailDto result = await mediator.Send(new SRLDevelopmentActorProfileDetailByOwnerQuery(key));

            SRLDevelopmentActorProfileDetailDtoModel model = mapper.Map<SRLDevelopmentActorProfileDetailDtoModel>(result);

            return Ok(model);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<SRLDevelopmentActorProfileDetailDtoModel>> CreateAsync(SRLDevelopmentActorProfileCreateRequestModel model)
    {
        try
        {
            SRLDevelopmentActorProfileCreateCommand command = mapper.Map<SRLDevelopmentActorProfileCreateCommand>(model);

            SRLDevelopmentActorProfileDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<SRLDevelopmentActorProfileDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<SRLDevelopmentActorProfileDetailDtoModel>> UpdateAsync(SRLDevelopmentActorProfileUpdateRequestModel model)
    {
        try
        {
            SRLDevelopmentActorProfileUpdateCommand command = mapper.Map<SRLDevelopmentActorProfileUpdateCommand>(model);

            SRLDevelopmentActorProfileDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<SRLDevelopmentActorProfileDetailDtoModel>(result));
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
            await mediator.Send(new SRLDevelopmentActorProfileEnableCommand(key));

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
            await mediator.Send(new SRLDevelopmentActorProfileDisableCommand(key));

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
            await mediator.Send(new SRLDevelopmentActorProfileUnarchiveCommand(key));

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
            await mediator.Send(new SRLDevelopmentActorProfileArchiveCommand(key));

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
            await mediator.Send(new SRLDevelopmentActorProfileRemoveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}