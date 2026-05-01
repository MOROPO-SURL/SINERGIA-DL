using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;

public abstract class AbstractBaseAdministrationArchivableController<
    TEntity,
    TId,
    TIdValue,
    TBasicViewModel,
    TDetailViewModel,
    TBasicDto,
    TDetailDto,
    TPaginateQuery,
    TDetailQuery,
    TRemoveCommand,
    TArchiveCommand,
    TUnarchiveCommand>
    : AbstractBaseRemotionController<TEntity, TId, TIdValue, TBasicViewModel, TDetailViewModel, TBasicDto, TDetailDto, TPaginateQuery, TDetailQuery, TRemoveCommand>
    where TEntity : class, IEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TPaginateQuery : IPaginateQuery<TEntity, TId, TIdValue, TBasicDto>, IRequest<PaginateQueryResultModel<TBasicDto>>
    where TDetailQuery : IRequest<TDetailDto>
    where TBasicDto : IDto
    where TArchiveCommand : IRequest
    where TUnarchiveCommand : IRequest
    where TRemoveCommand : IRequest
{
    protected AbstractBaseAdministrationArchivableController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }

    [HttpPost]
    [Route("archive")]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> ArchiveAsync(TIdValue id)
    {
        try
        {
            TArchiveCommand command = mapper.Map<TArchiveCommand>(id!);

            await mediator.Send(command);

            PushNotification(NotificationKind.Success, GetArchiveSuccessMessage());

            return GetDefaultActionResult();
        }
        catch { }

        PushNotification(NotificationKind.Danger, GetNotFoundMessage());

        return GetDefaultActionResult();
    }

    [HttpPost]
    [Route("unarchive")]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> UnarchiveAsync(TIdValue id)
    {
        try
        {
            TUnarchiveCommand command = mapper.Map<TUnarchiveCommand>(id!);

            await mediator.Send(command);

            PushNotification(NotificationKind.Success, GetUnarchiveSuccessMessage());

            return GetDefaultActionResult();
        }
        catch { }

        PushNotification(NotificationKind.Danger, GetNotFoundMessage());

        return GetDefaultActionResult();
    }

    #region Messages

    protected virtual string GetArchiveSuccessMessage() => "ArchiveSuccessMessage";

    protected virtual string GetUnarchiveSuccessMessage() => "UnarchiveSuccessMessage";

    #endregion
}