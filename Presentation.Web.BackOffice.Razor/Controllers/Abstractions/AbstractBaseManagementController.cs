using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;

public abstract class AbstractBaseManagementController<
    TEntity,
    TId,
    TIdValue,
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
    : AbstractBaseViewingController<TEntity, TId, TIdValue, TBasicViewModel, TDetailViewModel,TBasicDto, TDetailDto, TPaginateQuery, TDetailQuery, TRemoveCommand>
    where TEntity : class, IEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TPaginateQuery : IPaginateQuery<TEntity, TId, TIdValue, TBasicDto>, IRequest<PaginateQueryResultModel<TBasicDto>>
    where TDetailQuery : IRequest<TDetailDto>
    where TBasicDto : IDto
    where TCreateCommand : IRequest<TDetailDto>
    where TUpdateCommand : IRequest<TDetailDto>
    where TRemoveCommand : IRequest
{
    protected AbstractBaseManagementController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
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

                    TIdValue id = mapper.Map<TIdValue>(result!);

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

                    return GetSuccessEditActionResult(mapper.Map<TIdValue>(result!));
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

    protected virtual IActionResult GetSuccessCreateActionResult(TIdValue key)
    {
        return GetDefaultActionResult();
    }

    protected virtual IActionResult GetSuccessEditActionResult(TIdValue key)
    {
        return RedirectToAction("edit", new { key });
    }

    #endregion

    #region Messages

    protected virtual string GetCreationSuccessMessage() => "CreationSuccessMessage";

    protected virtual string GetEditionSuccessMessage() => "EditionSuccessMessage";

    #endregion
}