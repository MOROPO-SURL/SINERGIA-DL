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
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.LegalOwnedPDLDevelopmentActorProfiles.CQRS.Query.List;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.DevelopmentActorProfile.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/legalownedpdldevelopmentactorprofiles")]
public class LegalOwnedPDLDevelopmentActorProfilesController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public LegalOwnedPDLDevelopmentActorProfilesController(ISender mediator, IMapper mapper, ILogger<LegalOwnedPDLDevelopmentActorProfilesController> logger)
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
            PaginateQueryResultModel<DevelopmentActorProfileBasicDto> result = await mediator.Send(new LegalOwnedPDLDevelopmentActorProfilePaginateQuery(sheet, limit, entity => !entity.IsArchived));

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
            PaginateQueryResultModel<DevelopmentActorProfileBasicDto> result = await mediator.Send(new LegalOwnedPDLDevelopmentActorProfilePaginateQuery(
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
    public async Task<ActionResult<LegalOwnedPDLDevelopmentActorProfileDetailDtoModel[]>> GetAsync()
    {
        try
        {
            LegalOwnedPDLDevelopmentActorProfileDetailDto[] result = await mediator.Send(new LegalOwnedPDLDevelopmentActorProfileListQuery());

            return Ok(mapper.Map<LegalOwnedPDLDevelopmentActorProfileDetailDtoModel[]>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<LegalOwnedPDLDevelopmentActorProfileDetailDtoModel>> GetAsync(Guid key)
    {
        try
        {
            LegalOwnedPDLDevelopmentActorProfileDetailDto result = await mediator.Send(new LegalOwnedPDLDevelopmentActorProfileDetailQuery(key));

            LegalOwnedPDLDevelopmentActorProfileDetailDtoModel model = mapper.Map<LegalOwnedPDLDevelopmentActorProfileDetailDtoModel>(result);

            return Ok(model);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("by/owner/{key}")]
    public async Task<ActionResult<LegalOwnedPDLDevelopmentActorProfileDetailDtoModel>> GetBasicByOwnerAsync(Guid key)
    {
        try
        {
            DevelopmentActorProfileBasicDto result = await mediator.Send(new LegalOwnedPDLDevelopmentActorProfileBasicByOwnerQuery(key));

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
    public async Task<ActionResult<LegalOwnedPDLDevelopmentActorProfileDetailDtoModel>> GetDetailByOwnerAsync(Guid key)
    {
        try
        {
            LegalOwnedPDLDevelopmentActorProfileDetailDto result = await mediator.Send(new LegalOwnedPDLDevelopmentActorProfileDetailByOwnerQuery(key));

            LegalOwnedPDLDevelopmentActorProfileDetailDtoModel model = mapper.Map<LegalOwnedPDLDevelopmentActorProfileDetailDtoModel>(result);

            return Ok(model);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<LegalOwnedPDLDevelopmentActorProfileDetailDtoModel>> CreateAsync(LegalOwnedPDLDevelopmentActorProfileCreateRequestModel model)
    {
        try
        {
            LegalOwnedPDLDevelopmentActorProfileCreateCommand command = mapper.Map<LegalOwnedPDLDevelopmentActorProfileCreateCommand>(model);

            LegalOwnedPDLDevelopmentActorProfileDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<LegalOwnedPDLDevelopmentActorProfileDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<LegalOwnedPDLDevelopmentActorProfileDetailDtoModel>> UpdateAsync(LegalOwnedPDLDevelopmentActorProfileUpdateRequestModel model)
    {
        try
        {
            LegalOwnedPDLDevelopmentActorProfileUpdateCommand command = mapper.Map<LegalOwnedPDLDevelopmentActorProfileUpdateCommand>(model);

            LegalOwnedPDLDevelopmentActorProfileDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<LegalOwnedPDLDevelopmentActorProfileDetailDtoModel>(result));
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
    //        await mediator.Send(new LegalOwnedPDLDevelopmentActorProfileEnableCommand(key));

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
    //        await mediator.Send(new LegalOwnedPDLDevelopmentActorProfileDisableCommand(key));

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
    //        await mediator.Send(new LegalOwnedPDLDevelopmentActorProfileUnarchiveCommand(key));

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
    //        await mediator.Send(new LegalOwnedPDLDevelopmentActorProfileArchiveCommand(key));

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
    //        await mediator.Send(new LegalOwnedPDLDevelopmentActorProfileRemoveCommand(key));

    //        return Ok();
    //    }
    //    catch (Exception exception)
    //    {
    //        logger.LogError(exception, exception.Message);

    //        return Problem();
    //    }
    //}
}