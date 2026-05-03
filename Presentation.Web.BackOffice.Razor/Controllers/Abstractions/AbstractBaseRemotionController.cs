using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;

public abstract class AbstractBaseRemotionController<
    TEntity,
    TId,
    TIdValue,
    TBasicViewModel,
    TDetailViewModel,
    TBasicDto,
    TDetailDto,
    TPaginateQuery,
    TDetailQuery,
    TRemoveCommand>
    : AbstractBaseViewingController<
        TEntity,
        TId,
        TIdValue,
        TBasicViewModel,
        TDetailViewModel,
        TBasicDto,
        TDetailDto,
        TPaginateQuery,
        TDetailQuery>
    where TEntity : class, IEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TPaginateQuery : IPaginateQuery<TEntity, TId, TIdValue, TBasicDto>, IRequest<PaginateQueryResultModel<TBasicDto>>
    where TDetailQuery : IRequest<TDetailDto>
    where TBasicDto : IDto
    where TRemoveCommand : IRequest
{
    protected AbstractBaseRemotionController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }

    [HttpPost]
    [Route("remove")]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> RemoveAsync(TIdValue id)
    {
        try
        {
            var command = mapper.Map<TRemoveCommand>(id!);

            await mediator.Send(command);

            PushNotification(NotificationKind.Success, GetDeletionSuccessMessage());

            return GetDefaultActionResult();
        }
        catch { }

        PushNotification(NotificationKind.Danger, GetNotFoundMessage());

        return GetDefaultActionResult();
    }

    #region ActionResults

    protected virtual IActionResult GetDefaultActionResult()
    {
        return RedirectToAction("index");
    }

    #endregion

    #region Messages

    protected virtual string GetNotFoundMessage() => "NotFoundMessage";

    protected virtual string GetWorkflowBreakMessage() => "WorkflowBreakMessage";

    protected virtual string GetDeletionSuccessMessage() => "DeletionSuccessMessage";

    #endregion
}