using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.User.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.User.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Controllers;

[Authorize]
[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public UsersController(ISender mediator, IMapper mapper, ILogger<UsersController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<UserBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<UserBasicDto> result = await mediator.Send(new UserPaginateQuery(sheet, limit));

            return Ok(mapper.Map<PaginateResultModel<UserBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<UserBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
    {
        try
        {
            PaginateQueryResultModel<UserBasicDto> result = await mediator.Send(new UserPaginateQuery(sheet, limit, entity => EF.Functions.ILike(entity.Name, $"%{parameter}%")));

            return Ok(mapper.Map<PaginateResultModel<UserBasicDtoModel>>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<UserDetailDtoModel>> GetAsync(string key)
    {
        try
        {
            UserDetailDto result = await mediator.Send(new UserDetailQuery(key));

            return Ok(mapper.Map<UserDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<UserDetailDtoModel>> CreateAsync(UserCreateRequestModel model)
    {
        try
        {
            UserCreateCommand command = mapper.Map<UserCreateCommand>(model);

            UserDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<UserDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<UserDetailDtoModel>> UpdateAsync(UserUpdateRequestModel model)
    {
        try
        {
            FullUserUpdateCommand command = mapper.Map<FullUserUpdateCommand>(model);

            UserDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<UserDetailDtoModel>(result));
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPatch("{key}/enable")]
    public async Task<IActionResult> EnableAsync(string key)
    {
        try
        {
            await mediator.Send(new UserEnableCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpPatch("{key}/disable")]
    public async Task<IActionResult> DisableAsync(string key)
    {
        try
        {
            await mediator.Send(new UserDisableCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }

    [HttpDelete("{key}")]
    public async Task<IActionResult> DeleteAsync(string key)
    {
        try
        {
            await mediator.Send(new UserRemoveCommand(key));

            return Ok();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            return Problem();
        }
    }
}