using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.DevelopmentActorProfiles.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.NaturalOwnedPDLDevelopmentActorProfiles.CQRS.Query.List;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.DevelopmentActorProfile.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/naturalownedpdldevelopmentactorprofiles")]
public class NaturalOwnedPDLDevelopmentActorProfilesController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public NaturalOwnedPDLDevelopmentActorProfilesController(ISender mediator, IMapper mapper, ILogger<NaturalOwnedPDLDevelopmentActorProfilesController> logger)
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
            PaginateQueryResultModel<DevelopmentActorProfileBasicDto> result = await mediator.Send(new NaturalOwnedPDLDevelopmentActorProfilePaginateQuery(sheet, limit, entity => !entity.IsArchived));

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
            PaginateQueryResultModel<DevelopmentActorProfileBasicDto> result = await mediator.Send(new NaturalOwnedPDLDevelopmentActorProfilePaginateQuery(
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
    public async Task<ActionResult<NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel[]>> GetAsync()
    {
        try
        {
            NaturalOwnedPDLDevelopmentActorProfileDetailDto[] result = await mediator.Send(new NaturalOwnedPDLDevelopmentActorProfileListQuery());

            return Ok(mapper.Map<NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel[]>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel>> GetAsync(Guid key)
    {
        try
        {
            NaturalOwnedPDLDevelopmentActorProfileDetailDto result = await mediator.Send(new NaturalOwnedPDLDevelopmentActorProfileDetailQuery(key));

            NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel model = mapper.Map<NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel>(result);

            return Ok(model);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("by/owner/{key}")]
    public async Task<ActionResult<NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel>> GetBasicByOwnerAsync(Guid key)
    {
        try
        {
            DevelopmentActorProfileBasicDto result = await mediator.Send(new NaturalOwnedPDLDevelopmentActorProfileBasicByOwnerQuery(key));

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
    public async Task<ActionResult<NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel>> GetDetailByOwnerAsync(Guid key)
    {
        try
        {
            NaturalOwnedPDLDevelopmentActorProfileDetailDto result = await mediator.Send(new NaturalOwnedPDLDevelopmentActorProfileDetailByOwnerQuery(key));

            NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel model = mapper.Map<NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel>(result);

            return Ok(model);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel>> CreateAsync(NaturalOwnedPDLDevelopmentActorProfileCreateRequestModel model)
    {
        try
        {
            NaturalOwnedPDLDevelopmentActorProfileCreateCommand command = mapper.Map<NaturalOwnedPDLDevelopmentActorProfileCreateCommand>(model);

            NaturalOwnedPDLDevelopmentActorProfileDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel>> UpdateAsync(NaturalOwnedPDLDevelopmentActorProfileUpdateRequestModel model)
    {
        try
        {
            NaturalOwnedPDLDevelopmentActorProfileUpdateCommand command = mapper.Map<NaturalOwnedPDLDevelopmentActorProfileUpdateCommand>(model);

            NaturalOwnedPDLDevelopmentActorProfileDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    //[HttpPatch("{key}/enable")]
    //public async Task<IActionResult> EnableAsync(Guid key)
    //{
    //    try
    //    {
    //        await mediator.Send(new NaturalOwnedPDLDevelopmentActorProfileEnableCommand(key));

    //        return Ok();
    //    }
    //    catch (Exception exception)
    //    {
    //        logger.LogError(exception, exception.Message);

    //        return Problem();
    //    }
    //}

    //[HttpPatch("{key}/disable")]
    //public async Task<IActionResult> DisableAsync(Guid key)
    //{
    //    try
    //    {
    //        await mediator.Send(new NaturalOwnedPDLDevelopmentActorProfileDisableCommand(key));

    //        return Ok();
    //    }
    //    catch (Exception exception)
    //    {
    //        logger.LogError(exception, exception.Message);

    //        return Problem();
    //    }
    //}

    //[HttpPatch("{key}/unarchive")]
    //public async Task<IActionResult> UnarchiveAsync(Guid key)
    //{
    //    try
    //    {
    //        await mediator.Send(new NaturalOwnedPDLDevelopmentActorProfileUnarchiveCommand(key));

    //        return Ok();
    //    }
    //    catch (Exception exception)
    //    {
    //        logger.LogError(exception, exception.Message);

    //        return Problem();
    //    }
    //}

    //[HttpPatch("{key}/archive")]
    //public async Task<IActionResult> ArchiveAsync(Guid key)
    //{
    //    try
    //    {
    //        await mediator.Send(new NaturalOwnedPDLDevelopmentActorProfileArchiveCommand(key));

    //        return Ok();
    //    }
    //    catch (Exception exception)
    //    {
    //        logger.LogError(exception, exception.Message);

    //        return Problem();
    //    }
    //}

    //[HttpDelete("{key}")]
    //public async Task<IActionResult> DeleteAsync(Guid key)
    //{
    //    try
    //    {
    //        await mediator.Send(new NaturalOwnedPDLDevelopmentActorProfileRemoveCommand(key));

    //        return Ok();
    //    }
    //    catch (Exception exception)
    //    {
    //        logger.LogError(exception, exception.Message);

    //        return Problem();
    //    }
    //}
}