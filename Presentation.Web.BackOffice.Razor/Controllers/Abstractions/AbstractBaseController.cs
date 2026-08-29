using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Constants;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Enumerations;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;

[Microsoft.AspNetCore.Authorization.Authorize]
public class AbstractBaseController : Controller
{

    #region Messages

    protected virtual string GetInvalidMessage() => "InvalidMessage";

    #endregion

    #region Notifications

    protected bool HasDefaultNotification { get => TempData.ContainsKey(SessionConstants.NOTIFICATION_DICTIONARY_KEY) && TempData[SessionConstants.NOTIFICATION_DICTIONARY_KEY] != null; }

    protected void PushNotification(NotificationViewModel notification)
    {
        TempData[SessionConstants.NOTIFICATION_DICTIONARY_KEY] = System.Text.Json.JsonSerializer.Serialize(notification);
    }

    protected void PushNotification(NotificationKind kind, string message)
    {
        var notification = new NotificationViewModel { Kind = kind, MainMessage = message };

        TempData[SessionConstants.NOTIFICATION_DICTIONARY_KEY] = System.Text.Json.JsonSerializer.Serialize(notification);
    }

    protected void PushNotification(NotificationKind kind, string title, string message)
    {
        var notification = new NotificationViewModel { Kind = kind, MainMessage = message, Title = title };

        TempData[SessionConstants.NOTIFICATION_DICTIONARY_KEY] = System.Text.Json.JsonSerializer.Serialize(notification);
    }

    protected void PushNotification(NotificationKind kind, string[] messages)
    {
        var notification = new NotificationViewModel { Kind = kind, DetailMessages = messages };

        TempData[SessionConstants.NOTIFICATION_DICTIONARY_KEY] = System.Text.Json.JsonSerializer.Serialize(notification);
    }

    protected void PushNotification(NotificationKind kind, string title, string[] messages)
    {
        var notification = new NotificationViewModel { Kind = kind, Title = title, DetailMessages = messages };

        TempData[SessionConstants.NOTIFICATION_DICTIONARY_KEY] = System.Text.Json.JsonSerializer.Serialize(notification);
    }

    protected void PushNotification(NotificationKind kind, string title, string message, string[] messages)
    {
        var notification = new NotificationViewModel { Kind = kind, MainMessage = message, Title = title, DetailMessages = messages };

        TempData[SessionConstants.NOTIFICATION_DICTIONARY_KEY] = System.Text.Json.JsonSerializer.Serialize(notification);
    }

    #endregion
}
