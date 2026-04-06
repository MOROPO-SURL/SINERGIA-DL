using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Create;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Remove;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Update;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.Detail;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.Paginate;
using MOROPO.GEDET.CAM.Interop.Contracts.Models.Common;
using MOROPO.GEDET.CAM.Interop.Contracts.Models.Role.CQRS.Command;
using MOROPO.GEDET.CAM.Interop.Contracts.Models.Role.DTOs;

namespace MOROPO.GEDET.CAM.Presentation.Web.API.Controllers;

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
    [Route("page")]
    [Route("page/{sheet}")]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<ActionResult<PaginateResultModel<RoleBasiclModel>>> GetAsync(int sheet = 1, int limit = 20)
    {
        try
        {
            var result = await mediator.Send(new RolePaginateQuery(sheet, limit));

            return Ok(mapper.Map<PaginateResultModel<RoleBasiclModel>>(result));
        }
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult<RoleDetailModel>> GetAsync(Guid key)
    {
        try
        {
            var result = await mediator.Send(new RoleDetailQuery(key));

            return Ok(mapper.Map<RoleDetailModel>(result));
        }
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpPost]
    public async Task<ActionResult<RoleDetailModel>> CreateAsync(RoleCreateRequestModel model)
    {
        try
        {
            var command = mapper.Map<RoleCreateRequestModel, RoleCreateCommand>(model);

            var result = await mediator.Send(command);

            return Ok(mapper.Map<RoleDetailModel>(result));
        }
        catch (Exception)
        {
            return Problem();
        }
    }

    [HttpPut]
    public async Task<ActionResult<RoleDetailModel>> UpdateAsync(RoleUpdateRequestModel model)
    {
        try
        {
            var command = mapper.Map<RoleUpdateRequestModel, IUpdateCommand>(model);

            var result = await mediator.Send(command);

            return Ok(mapper.Map<RoleDetailModel>(result));
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
            await mediator.Send(new IRemoveCommand(key));

            return Ok();
        }
        catch (Exception)
        {
            return Problem();
        }
    }
}
