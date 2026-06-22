using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Enumerations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicLines;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Management.EDL;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/lines")]
[Area("edl")]
public sealed class StrategicLinesController : AbstractBaseController
{
    private readonly IMapper mapper;
    private readonly ISender mediator;

    public StrategicLinesController(IMapper mapper, ISender mediator)
    {
        this.mapper = mapper;
        this.mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    [Route("page/{sheet}")]
    [Route("page/{sheet}/limit/{limit}")]
    public async Task<IActionResult> IndexAsync(int sheet = 1, int limit = 25)
    {
        StrategicLinePaginateQuery query = new(sheet, limit);

        PaginateQueryResultModel<StrategicLineBasicDto> result = await mediator.Send(query);

        return View(mapper.Map<PaginateResultViewModel<StrategicLineBasicViewModel>>(result));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> DetailAsync(Guid id)
    {
        if (Request.Headers.XRequestedWith != "XMLHttpRequest") return NotFound();

        try
        {
            StrategicLineDetailQuery query = new(id);

            StrategicLineDetailDto result = await mediator.Send(query);

            return View("_DetailParcial", mapper.Map<StrategicLineDetailViewModel>(result!));
        }
        catch
        {
            return Problem();
        }
    }

    [HttpPost]
    [Route("remove")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveAsync(Guid id)
    {
        try
        {
            StrategicLineRemoveCommand command = new(id);

            await mediator.Send(command);

            PushNotification(NotificationKind.Success, GetDeletionSuccessMessage());

            return GetDefaultActionResult();
        }
        catch { }

        PushNotification(NotificationKind.Danger, GetNotFoundMessage());

        return GetDefaultActionResult();
    }

    [HttpPost]
    [Route("archive")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ArchiveAsync(Guid id)
    {
        try
        {
            StrategicLineArchiveCommand command = new(id);

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
    public async Task<IActionResult> UnarchiveAsync(Guid id)
    {
        try
        {
            StrategicLineUnarchiveCommand command = new(id);

            await mediator.Send(command);

            PushNotification(NotificationKind.Success, GetUnarchiveSuccessMessage());

            return GetDefaultActionResult();
        }
        catch { }

        PushNotification(NotificationKind.Danger, GetNotFoundMessage());

        return GetDefaultActionResult();
    }

    [HttpPost]
    [Route("enable")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EnableAsync(Guid id)
    {
        try
        {
            StrategicLineEnableCommand command = new(id);

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
    public async Task<IActionResult> DisableAsync(Guid id)
    {
        try
        {
            StrategicLineDisableCommand command = new(id);

            await mediator.Send(command);

            PushNotification(NotificationKind.Success, GetDisableSuccessMessage());

            return GetDefaultActionResult();
        }
        catch { }

        PushNotification(NotificationKind.Danger, GetNotFoundMessage());

        return GetDefaultActionResult();
    }

    #region ActionResults

    private IActionResult GetDefaultActionResult()
    {
        return RedirectToAction("index");
    }

    #endregion

    #region Messages

    private string GetNotFoundMessage() => "NotFoundMessage";

    private string GetWorkflowBreakMessage() => "WorkflowBreakMessage";

    private string GetDeletionSuccessMessage() => "DeletionSuccessMessage";

    private string GetArchiveSuccessMessage() => "ArchiveSuccessMessage";

    private string GetUnarchiveSuccessMessage() => "UnarchiveSuccessMessage";

    private string GetEnableSuccessMessage() => "EnableSuccessMessage";

    private string GetDisableSuccessMessage() => "DisableSuccessMessage";

    #endregion
}
