using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Filters.Action.Attributes;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Authentication.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Enumerations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Authentication;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Session;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers;

[Authorize]
[Route("[controller]")]
public class SessionController : AbstractBaseController
{
    private readonly IMapper mapper;
    private readonly ISender mediator;

    public SessionController(IMapper mapper, ISender mediator)
    {
        this.mapper = mapper;
        this.mediator = mediator;
    }

    [HttpGet]
    [ChangePasswordRequiredActionFilter]
    public async Task<IActionResult> IndexAsync()
    {
        var result = await mediator.Send(new UserDetailQuery(User.Identity!.Name!));

        return View(mapper.Map<SessionProfileDetailViewModel>(result));
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> EditAsync()
    {
        var result = await mediator.Send(new UserDetailQuery(User.Identity!.Name!));

        return View(mapper.Map<SessionProfileUpdateViewModel>(result));
    }

    [HttpPost]
    [Route("[action]")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditAsync(SessionProfileUpdateViewModel model)
    {
        var notification = new NotificationViewModel
        {
            Kind = NotificationKind.Danger,
            MainMessage = GetInvalidMessage()
        };

        if (ModelState.IsValid)
        {
            EssentialUserUpdateCommand command = mapper.Map<EssentialUserUpdateCommand>(model);

            await mediator.Send(command);

            notification.Kind = NotificationKind.Success;
            notification.MainMessage = "UserProfileEditSuccessMessage";

            PushNotification(notification);

            return RedirectToAction("edit");
        }

        return View(model);
    }

    [HttpGet]
    [Route("[action]")]
    public IActionResult Password()
    {
        return View();
    }

    [HttpPost]
    [Route("[action]")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PasswordAsync(SessionChangePasswordUpdateViewModel model)
    {
        var notification = new NotificationViewModel
        {
            Kind = NotificationKind.Danger,
            MainMessage = GetInvalidMessage()
        };

        if (ModelState.IsValid)
        {
            try
            {
                var command = new PasswordUserUpdateCommand(User.Identity!.Name!, model.NewPassword);

                await mediator.Send(command);

                notification.Kind = NotificationKind.Success;
                notification.MainMessage = "ChangePasswordSuccessMessage";

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                PushNotification(notification);

                return RedirectToAction("login");
            }
            catch
            {
                ModelState.AddModelError(nameof(SessionChangePasswordUpdateViewModel.CurrentPassword), "InvalidCurrentPasswordMessage");
            }
        }

        PushNotification(notification);

        return View(model);
    }

    [HttpGet]
    [Route("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;

        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return View();
    }

    [HttpPost()]
    [Route("[action]")]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LoginAsync(AuthenticateRequestModel model, string? returnUrl = null)
    {
        if (Url.Action("logout", "session")!.Equals(returnUrl))
        {
            returnUrl = null;
        }

        var notification = new NotificationViewModel { Kind = NotificationKind.Danger, MainMessage = "InvalidAuthenticationDataMessage" };

        ViewData["ReturnUrl"] = returnUrl;

        if (ModelState.IsValid)
        {
            try
            {
                // TODO Include captcha handling for brutforce attact !!! 
                //if (HttpContext.Session.Keys.Contains(HttpSessionMapKeys.CaptchaCodeKey))
                //{
                //    var captchaCode = HttpContext.Session.GetString(HttpSessionMapKeys.CaptchaCodeKey);

                //    if (captchaCode != model.CaptchaCode)
                //    {
                //        ModelState.AddModelError("CaptchaCode", "InvalidVerificationCodeMessage");

                //        notification.MainMessage = "InvalidMessage";

                //        throw new ForceAuthenticationDetectException();
                //    }
                //}

                var command = mapper.Map<AuthenticateCommand>(model);

                var result = await mediator.Send(command);

                //HttpContext.Session.Remove(HttpSessionMapKeys.CaptchaCodeKey);

                await HttpContext.SignInAsync(result.Identity.AuthenticationType, new System.Security.Claims.ClaimsPrincipal(result.Identity), new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                    IsPersistent = model.RememberMe
                });

                return RedirectToLocal(returnUrl);
            }
            // User not found!!
            catch (ArgumentOutOfRangeException)
            {
                notification.MainMessage = "WrongCredentialMessage";
            }
            // User signature validation fail!!
            catch (InvalidDataException)
            {
                notification.MainMessage = "UserCorruptMessage";
            }
            // User disabled!!
            catch (InvalidOperationException)
            {
                notification.MainMessage = "UserDisabledMessage";
            }
            // Max authentication failure reached!!
            catch (AccessViolationException)
            {
                //    var captchaCode = Core.Presentation.Web.Security.Helpers.CaptchaHelper.GenerateCode(identityProvider.GetCaptchaCodeLength());

                //    HttpContext.Session.SetString(HttpSessionMapKeys.CaptchaCodeKey, captchaCode);

                notification.MainMessage = "MaxFailAttempReachedMessage";
            }
            // Credentials missmatch!!  
            catch (UnauthorizedAccessException)
            {
                notification.MainMessage = "WrongCredentialMessage";
            }
            catch
            {
                notification.MainMessage = "KnownErrorMessage";
            }
        }
        //else
        //{
        //    if (HttpContext.Session.Keys.Contains(HttpSessionMapKeys.CaptchaCodeKey))
        //    {
        //        var captchaCode = HttpContext.Session.GetString(HttpSessionMapKeys.CaptchaCodeKey);

        //        if (ModelState["CaptchaCode"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid || captchaCode != model.CaptchaCode)
        //        {
        //            notification.Message = "InvalidMessage";
        //        }

        //        var newCaptchaCode = Core.Presentation.Web.Security.Helpers.CaptchaHelper.GenerateCode(identityProvider.GetCaptchaCodeLength());

        //        HttpContext.Session.SetString(HttpSessionMapKeys.CaptchaCodeKey, newCaptchaCode);
        //    }
        //}

        PushNotification(notification);

        //model.CaptchaCode = string.Empty;

        return View("login", model);
    }

    [HttpPost]
    [Route("[action]")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return Redirect("/");
    }

    [NonAction]
    private IActionResult RedirectToLocal(string? returnUrl)
    {
        if (Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }
        else
        {
            return Redirect("/");
        }
    }
}
