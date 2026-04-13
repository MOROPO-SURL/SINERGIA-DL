using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Query.List;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Enumerations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Common.Input;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Users;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Security;

[Route("management/[area]/[controller]")]
[Area("security")]
public sealed class UsersController : AbstractBaseManagementController<
        string,
        UserBasicViewModel,
        UserDetailViewModel,
        UserCreateViewModel,
        UserUpdateViewModel,
        UserBasicDto,
        UserDetailDto,
        UserPaginateQuery,
        UserDetailQuery,
        UserCreateCommand,
        FullUserUpdateCommand,
        UserRemoveCommand>
{
    public UsersController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }

    protected override async Task<UserCreateViewModel> BuildCreateViewModelAsync()
    {
        RoleBasicDto[] roles = await mediator.Send(new RoleListQuery());

        return new UserCreateViewModel
        {
            SelectableRoles = roles.Select(item => new SelectionDescriptedItemInputViewModel<Guid>
            {
                Id = item.Id,
                Label = item.Name
            }).ToArray()
        };
    }

    protected override async Task ConfigureViewModelAsync(UserCreateViewModel model)
    {
        RoleBasicDto[] roles = await mediator.Send(new RoleListQuery());

        model.SelectableRoles = roles.Select(item => new SelectionDescriptedItemInputViewModel<Guid>
        {
            Id = item.Id,
            Selected = model.SelectableRoles.Any(_item => _item.Id.Equals(item.Id)),
            Label = item.Name
        }).ToArray();
    }

    protected override async Task ConfigureViewModelAsync(UserUpdateViewModel model)
    {
        RoleBasicDto[] roles = await mediator.Send(new RoleListQuery());

        model.SelectableRoles = roles.Select(item => new SelectionDescriptedItemInputViewModel<Guid>
        {
            Id = item.Id,
            Selected = model.SelectableRoles.Any(_item => _item.Id.Equals(item.Id)),
            Label = item.Name
        }).ToArray();
    }

    //[RequirePermissions(Core.Security.Presentation.Constants.Permissions.UserEditor)]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> ChangePasswordAsync(UserChangePasswordViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if (model.UserId == User.Identity!.Name)
                {
                    PushNotification(NotificationKind.Warning, "Esta operación no puede ejecutarse para el usuario autenticado. Debe realizarlo desde el perfil de usuario.");
                }
                else
                {
                    var command = mapper.Map<PasswordUserUpdateCommand>(model);

                    await mediator.Send(command);

                    PushNotification(NotificationKind.Success, GetDeletionSuccessMessage());
                }
            }
            catch
            {
                PushNotification(NotificationKind.Danger, GetNotFoundMessage());
            }
        }
        else
        {
            var validationErrorMessages = new List<string>();

            foreach (var record in ModelState)
            {
                foreach (var error in record.Value.Errors)
                {
                    validationErrorMessages.Add(error.ErrorMessage);
                }
            }

            PushNotification(NotificationKind.Danger, "Cambiar Contraseña." + (validationErrorMessages.Count > 1 ? " Múltiples errores." : ""), validationErrorMessages.ToArray());
        }

        return RedirectToAction("index");
    }
}
