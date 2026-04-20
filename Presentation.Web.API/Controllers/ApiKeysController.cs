using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.ApiKey.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.ApiKey.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Controllers;

[ApiController]
[Route("api/apikeys")]
public class ApiKeysController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;

    public ApiKeysController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<ApiKeyBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<ApiKeyBasicDto> result = await mediator.Send(new ApiKeyPaginateQuery(sheet, limit));

            return Ok(mapper.Map<PaginateResultModel<ApiKeyBasicDtoModel>>(result));
        }
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<ApiKeyBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
    {
        try
        {
            PaginateQueryResultModel<ApiKeyBasicDto> result = await mediator.Send(new ApiKeyPaginateQuery(sheet, limit, entity => EF.Functions.ILike(entity.Name, $"%{parameter}%")));

            return Ok(mapper.Map<PaginateResultModel<ApiKeyBasicDtoModel>>(result));
        }
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<ApiKeyDetailDtoModel>> GetAsync(Guid key)
    {
        try
        {
            ApiKeyDetailDto result = await mediator.Send(new ApiKeyDetailQuery(key));

            return Ok(mapper.Map<ApiKeyDetailDtoModel>(result));
        }
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<ApiKeyDetailDtoModel>> CreateAsync(ApiKeyCreateRequestModel model)
    {
        try
        {
            ApiKeyCreateCommand command = mapper.Map<ApiKeyCreateCommand>(model);

            ApiKeyDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<ApiKeyDetailDtoModel>(result));
        }
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<ApiKeyDetailDtoModel>> UpdateAsync(ApiKeyUpdateRequestModel model)
    {
        try
        {
            ApiKeyUpdateCommand command = mapper.Map<ApiKeyUpdateCommand>(model);

            ApiKeyDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<ApiKeyDetailDtoModel>(result));
        }
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpPatch("{key}/enable")]
    public async Task<IActionResult> EnableAsync(Guid key)
    {
        try
        {
            await mediator.Send(new ApiKeyEnableCommand(key));

            return Ok();
        }
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpPatch("{key}/disable")]
    public async Task<IActionResult> DisableAsync(Guid key)
    {
        try
        {
            await mediator.Send(new ApiKeyDisableCommand(key));

            return Ok();
        }
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpDelete("{key}")]
    public async Task<IActionResult> DeleteAsync(Guid key)
    {
        try
        {
            await mediator.Send(new ApiKeyRemoveCommand(key));

            return Ok();
        }
        catch (Exception)
        {
            return Problem();
        }
    }
}