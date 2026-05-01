using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;

public abstract class AbstractBaseViewingController<
    TEntity,
    TId,
    TIdValue,
    TBasicViewModel,
    TDetailViewModel,
    TBasicDto,
    TDetailDto,
    TPaginateQuery,
    TDetailQuery>
    : AbstractBaseController
    where TEntity : class, IEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TPaginateQuery : IPaginateQuery<TEntity, TId, TIdValue, TBasicDto>, IRequest<PaginateQueryResultModel<TBasicDto>>
    where TDetailQuery : IRequest<TDetailDto>
    where TBasicDto : IDto
{
    protected readonly IMapper mapper;
    protected readonly ISender mediator;

    protected AbstractBaseViewingController(IMapper mapper, ISender mediator)
    {
        this.mapper = mapper;
        this.mediator = mediator;
    }

    protected virtual TPaginateQuery Review(TPaginateQuery query)
    {
        return query;
    }

    [HttpGet]
    [Route("")]
    [Route("page/{sheet}")]
    [Route("page/{sheet}/limit/{limit}")]
    public virtual async Task<IActionResult> IndexAsync(int sheet = 1, int limit = 25)
    {
        TPaginateQuery query = mapper.Map<TPaginateQuery>((sheet, limit));

        query = Review(query);

        PaginateQueryResultModel<TBasicDto> result = await mediator.Send(query);

        return View(mapper.Map<PaginateResultViewModel<TBasicViewModel>>(result));
    }

    [HttpGet]
    [Route("{key}")]
    public virtual async Task<IActionResult> DetailAsync(TIdValue key)
    {
        if (Request.Headers.XRequestedWith != "XMLHttpRequest") return NotFound();

        try
        {
            TDetailQuery query = mapper.Map<TIdValue, TDetailQuery>(key);

            TDetailDto result = await mediator.Send(query);

            return View("_DetailParcial", mapper.Map<TDetailViewModel>(result!));
        }
        catch
        {
            return Problem();
        }
    }
}