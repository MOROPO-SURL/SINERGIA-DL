using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Role.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Role.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Controllers.Abstractions;

public abstract class AbstractQueryController<TCoreBasicDto, TInteropBasicDtoModel, TPaginateQuery> : ControllerBase
    where TPaginateQuery : IRequest<PaginateQueryResultModel<TCoreBasicDto>>
{
    //private readonly ISender mediator;
    //private readonly IMapper mapper;

    //public AbstractQueryController(ISender mediator, IMapper mapper)
    //{
    //    this.mediator = mediator;
    //    this.mapper = mapper;
    //}

    //[HttpGet]
    //[Route("page")]
    //[Route("page/{sheet}")]
    //[Route("page/{sheet}/limit/{limit}")]
    //public async Task<ActionResult<PaginateResultModel<TInteropBasicDtoModel>>> GetAsync(int sheet = 1, int limit = 20)
    //{
    //    try
    //    {
    //        PaginateQueryResultModel<TCoreBasicDto> result = await mediator.Send(new RolePaginateQuery(sheet, limit));

    //        return Ok(mapper.Map<PaginateResultModel<TInteropBasicDtoModel>>(result));
    //    }
    //    catch (Exception)
    //    {
    //        return Problem();
    //    }
    //}

    //[HttpGet("{key}")]
    //public async Task<ActionResult<RoleDetailDtoModel>> GetAsync(Guid key)
    //{
    //    try
    //    {
    //        var result = await mediator.Send(new RoleDetailQuery(key));

    //        return Ok(mapper.Map<RoleDetailDtoModel>(result));
    //    }
    //    catch (Exception)
    //    {
    //        return Problem();
    //    }
    //}

    //[HttpPost]
    //public async Task<ActionResult<RoleDetailDtoModel>> CreateAsync(RoleCreateRequestModel model)
    //{
    //    try
    //    {
    //        var command = mapper.Map<RoleCreateRequestModel, RoleCreateCommand>(model);

    //        var result = await mediator.Send(command);

    //        return Ok(mapper.Map<RoleDetailDtoModel>(result));
    //    }
    //    catch (Exception)
    //    {
    //        return Problem();
    //    }
    //}

    //[HttpPut]
    //public async Task<ActionResult<RoleDetailDtoModel>> UpdateAsync(RoleUpdateRequestModel model)
    //{
    //    try
    //    {
    //        var command = mapper.Map<RoleUpdateRequestModel, RoleUpdateCommand>(model);

    //        var result = await mediator.Send(command);

    //        return Ok(mapper.Map<RoleDetailDtoModel>(result));
    //    }
    //    catch (Exception)
    //    {
    //        return Problem();
    //    }
    //}

    //[HttpDelete("{key}")]
    //public async Task<IActionResult> DeleteAsync(Guid key)
    //{
    //    try
    //    {
    //        await mediator.Send(new RoleRemoveCommand(key));

    //        return Ok();
    //    }
    //    catch (Exception)
    //    {
    //        return Problem();
    //    }
    //}
}
