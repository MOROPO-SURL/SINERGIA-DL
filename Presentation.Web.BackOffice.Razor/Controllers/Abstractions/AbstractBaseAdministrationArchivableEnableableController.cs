using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;

public class AbstractBaseAdministrationArchivableEnableableController<
    TEntity,
    TId,
    TIdValue,
    TBasicViewModel,
    TDetailViewModel,
    TBasicDto,
    TDetailDto,
    TPaginateQuery,
    TDetailQuery,
    TArchiveCommand,
    TUnarchiveCommand,
    TRemoveCommand,
    TEnableCommand,
    TDisableCommand>
    : AbstractBaseAdministrationArchivableController<TEntity, TId, TIdValue, TBasicViewModel, TDetailViewModel, TBasicDto, TDetailDto, TPaginateQuery, TDetailQuery, TArchiveCommand, TUnarchiveCommand, TRemoveCommand>
    where TEntity : class, IEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TPaginateQuery : IPaginateQuery<TEntity, TId, TIdValue, TBasicDto>, IRequest<PaginateQueryResultModel<TBasicDto>>
    where TDetailQuery : IRequest<TDetailDto>
    where TBasicDto : IDto
    where TArchiveCommand : IRequest
    where TUnarchiveCommand : IRequest
    where TRemoveCommand : IRequest
    where TEnableCommand : IRequest
    where TDisableCommand : IRequest
{
    protected AbstractBaseAdministrationArchivableEnableableController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }

    [HttpPost]
    [Route("enable")]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> EnableAsync(TIdValue id)
    {
        try
        {
            TEnableCommand command = mapper.Map<TEnableCommand>(id!);

            await mediator.Send(command);

            PushNotification(NotificationKind.Success, GetEnableSuccessMessage());

            return GetDefaultActionResult();
        }
        catch { }

        PushNotification(NotificationKind.Danger, GetNotFoundMessage());

        return GetDefaultActionResult();
    }

    [HttpPost]
    [Route("disable")]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> DisableAsync(TIdValue id)
    {
        try
        {
            TDisableCommand command = mapper.Map<TDisableCommand>(id!);

            await mediator.Send(command);

            PushNotification(NotificationKind.Success, GetDisableSuccessMessage());

            return GetDefaultActionResult();
        }
        catch { }

        PushNotification(NotificationKind.Danger, GetNotFoundMessage());

        return GetDefaultActionResult();
    }

    #region Messages

    protected virtual string GetEnableSuccessMessage() => "EnableSuccessMessage";

    protected virtual string GetDisableSuccessMessage() => "DisableSuccessMessage";

    #endregion
}