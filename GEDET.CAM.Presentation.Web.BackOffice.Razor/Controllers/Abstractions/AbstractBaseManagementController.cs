using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.GEDET.CAM.Core.Common.Models;
using MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Enumerations;
using MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Models.View;

namespace MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;

public abstract class AbstractBaseManagementController<
    TId, 
    TBasicViewModel, 
    TDetailViewModel, 
    TCreateViewModel, 
    TUpdateViewModel, 
    TBasicDto, 
    TDetailDto, 
    TPaginateQuery, 
    TDetailQuery, 
    TCreateCommand, 
    TUpdateCommand, 
    TRemoveCommand> 
    : AbstractBaseController
    where TPaginateQuery : IRequest<PaginateQueryResultModel<TBasicDto>>
    where TDetailQuery : IRequest<TDetailDto>
    where TCreateCommand : IRequest<TDetailDto>
    where TUpdateCommand : IRequest<TDetailDto>
    where TRemoveCommand : IRequest
{
    protected readonly IMapper mapper;
    protected readonly ISender mediator;

    protected AbstractBaseManagementController(IMapper mapper, ISender mediator)
    {
        this.mapper = mapper;
        this.mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    [Route("page/{sheet}")]
    [Route("page/{sheet}/limit/{limit}")]
    public virtual async Task<IActionResult> IndexAsync(int sheet = 1, int limit = 25)
    {
        TPaginateQuery query = mapper.Map<TPaginateQuery>((sheet, limit));

        PaginateQueryResultModel<TBasicDto> result = await mediator.Send(query);

        return View(mapper.Map<PaginateResultViewModel<TBasicViewModel>>(result));
    }

    [HttpGet]
    [Route("{key}")]
    public virtual async Task<IActionResult> DetailAsync(TId key)
    {
        if (Request.Headers.XRequestedWith != "XMLHttpRequest") return NotFound();

        try
        {
            TDetailQuery query = mapper.Map<TId,TDetailQuery>(key);

            TDetailDto result = await mediator.Send(query);

            return View("_DetailParcial", mapper.Map<TDetailViewModel>(result!));
        }
        catch 
        {
            return Problem();
        }
    }

    [HttpPost]
    [Route("remove")]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> RemoveAsync(TId id)
    {
        try
        {
            var command = mapper.Map<TRemoveCommand>(id!);

            await mediator.Send(command);

            PushNotification(NotificationKind.Success, GetDeletionSuccessMessage());

            return GetSuccessDeleteActionResult();
        }
        catch {}

        PushNotification(NotificationKind.Danger, GetNotFoundMessage());

        return GetDefaultActionResult();
    }

    #region Create

    [HttpGet]
    [Route("create")]
    public virtual async Task<IActionResult> CreateAsync()
    {
        try
        {
            return View(await BuildCreateViewModelAsync());
        }
        catch { }

        PushNotification(NotificationKind.Warning, GetWorkflowBreakMessage());

        return GetDefaultActionResult();
    }

    protected abstract Task<TCreateViewModel> BuildCreateViewModelAsync();

    [HttpPost]
    [Route("create")]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> CreateAsync(TCreateViewModel model)
    {
        try
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TCreateCommand command = mapper.Map<TCreateCommand>(model!);

                    TDetailDto result = await mediator.Send(command);

                    PushNotification(NotificationKind.Success, GetCreationSuccessMessage());

                    TId id = mapper.Map<TId>(result!);

                    return GetSuccessCreateActionResult(id);
                }
            }
            catch
            {
                throw;
            }

            PushNotification(NotificationKind.Danger, GetInvalidMessage());

            await ConfigureViewModelAsync(model);

            return View(model);
        }
        catch { }

        PushNotification(NotificationKind.Warning, GetWorkflowBreakMessage());

        return GetDefaultActionResult();
    }

    protected virtual Task ConfigureViewModelAsync(TCreateViewModel model) { return Task.CompletedTask; }

    #endregion

    #region Edit

    [HttpGet]
    [Route("edit/{key}")]
    public virtual async Task<IActionResult> EditAsync(TId key)
    {
        try
        {
            TDetailQuery query = mapper.Map<TDetailQuery>(key!);

            TDetailDto detail = await mediator.Send(query);

            TUpdateViewModel model = mapper.Map<TUpdateViewModel>(detail!);

            await ConfigureViewModelAsync(model);

            return View(model);
        }
        catch { }

        PushNotification(NotificationKind.Danger, GetNotFoundMessage());

        return GetDefaultActionResult();
    }

    [HttpPost]
    [Route("edit")]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> EditAsync(TUpdateViewModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TUpdateCommand command = mapper.Map<TUpdateCommand>(model!);

                    TDetailDto result = await mediator.Send(command);

                    PushNotification(NotificationKind.Success, GetEditionSuccessMessage());

                    return GetSuccessEditActionResult(mapper.Map<TId>(result!));
                }
                catch
                {
                    throw;
                }
            }

            PushNotification(NotificationKind.Danger, GetInvalidMessage());

            await ConfigureViewModelAsync(model);

            return View(model);
        }
        catch { }

        PushNotification(NotificationKind.Warning, GetWorkflowBreakMessage());

        return GetDefaultActionResult();
    }

    protected virtual Task ConfigureViewModelAsync(TUpdateViewModel model) { return Task.CompletedTask; }

    #endregion

    #region ActionResults

    protected virtual IActionResult GetDefaultActionResult()
    {
        return RedirectToAction("index");
    }

    protected virtual IActionResult GetSuccessCreateActionResult(TId key)
    {
        return GetDefaultActionResult();
    }

    protected virtual IActionResult GetSuccessEditActionResult(TId key)
    {
        return RedirectToAction("edit", new { key });
    }

    protected virtual IActionResult GetSuccessDeleteActionResult()
    {
        return GetDefaultActionResult();
    }

    #endregion

    #region Messages

    protected virtual string GetNotFoundMessage() => "NotFoundMessage";

    protected virtual string GetWorkflowBreakMessage() => "WorkflowBreakMessage";

    protected virtual string GetCreationSuccessMessage() => "CreationSuccessMessage";

    protected virtual string GetEditionSuccessMessage() => "EditionSuccessMessage";

    protected virtual string GetDeletionSuccessMessage() => "DeletionSuccessMessage";

    #endregion
}