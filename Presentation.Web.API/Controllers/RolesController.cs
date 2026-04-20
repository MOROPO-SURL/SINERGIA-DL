using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Role.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Role.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Controllers;

[ApiController]
[Route("api/roles")]
public class RolesController : ControllerBase
{
    private readonly ISender mediator;
    private readonly IMapper mapper;

    public RolesController(ISender mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<RoleBasicDtoModel>>> GetAsync(int sheet, int limit)
    {
        try
        {
            PaginateQueryResultModel<RoleBasicDto> result = await mediator.Send(new RolePaginateQuery(sheet, limit));

            return Ok(mapper.Map<PaginateResultModel<RoleBasicDtoModel>>(result));
        }
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpGet]
    [Route("page/{sheet}/limit/{limit}/filter/{parameter}")]
    public async Task<ActionResult<PaginateResultModel<RoleBasicDtoModel>>> FilterAsync(int sheet, int limit, string parameter)
    {
        try
        {
            PaginateQueryResultModel<RoleBasicDto> result = await mediator.Send(new RolePaginateQuery(sheet, limit, entity => EF.Functions.ILike(entity.Name, $"%{parameter}%")));

            return Ok(mapper.Map<PaginateResultModel<RoleBasicDtoModel>>(result));
        }
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<RoleDetailDtoModel>> GetAsync(Guid key)
    {
        try
        {
            RoleDetailDto result = await mediator.Send(new RoleDetailQuery(key));

            return Ok(mapper.Map<RoleDetailDtoModel>(result));
        }
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<RoleDetailDtoModel>> CreateAsync(RoleCreateRequestModel model)
    {
        try
        {
            RoleCreateCommand command = mapper.Map<RoleCreateCommand>(model);

            RoleDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<RoleDetailDtoModel>(result));
        }
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<RoleDetailDtoModel>> UpdateAsync(RoleUpdateRequestModel model)
    {
        try
        {
            RoleUpdateCommand command = mapper.Map<RoleUpdateCommand>(model);

            RoleDetailDto result = await mediator.Send(command);

            return Ok(mapper.Map<RoleDetailDtoModel>(result));
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
            await mediator.Send(new RoleRemoveCommand(key));

            return Ok();
        }
        catch (Exception)
        {
            return Problem();
        }
    }
}
