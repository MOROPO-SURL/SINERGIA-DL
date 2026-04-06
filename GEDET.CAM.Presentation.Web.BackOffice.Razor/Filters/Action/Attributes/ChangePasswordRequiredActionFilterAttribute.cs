using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Constants;

namespace MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Filters.Action.Attributes;

internal sealed class ChangePasswordRequiredActionFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.HttpContext.User.Identity!.IsAuthenticated)
        {
            if (context.HttpContext.User.HasClaim(claim => claim.Type.Equals(Infrastructure.Constants.AuthorizationConstants.ClaimTypes.CHANGE_PASSWORD_REQUIRED)))
            {
                var notification = new Models.View.NotificationViewModel
                {
                    Kind = Enumerations.NotificationKind.Warning,
                    MainMessage = "PasswordChangeRequiredMessage"
                };

                (context.Controller as Controller)!.TempData[SessionConstants.NOTIFICATION_DICTIONARY_KEY] = System.Text.Json.JsonSerializer.Serialize(notification);

                context.Result = new RedirectToActionResult("password", "session", null);
            }
        }

        base.OnActionExecuting(context);
    }
}
