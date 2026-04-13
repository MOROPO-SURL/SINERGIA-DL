using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Permissions.CQRS.Query.List;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Permissions.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Roles;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.Common.Input;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Security;

[Route("management/[area]/[controller]")]
[Area("security")]
public sealed class RolesController : Abstractions.AbstractBaseManagementController<Guid, RoleBasicViewModel, RoleDetailViewModel, RoleCreateViewModel, RoleUpdateViewModel, RoleBasicDto, RoleDetailDto, RolePaginateQuery, RoleDetailQuery, RoleCreateCommand, RoleUpdateCommand, RoleRemoveCommand>
{
    public RolesController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }

    protected override async Task<RoleCreateViewModel> BuildCreateViewModelAsync()
    {
        PermissionDetailDto[] permissions = await mediator.Send(new PermissionListQuery());

        return new RoleCreateViewModel
        {
            UngroupedSelectablePermissions = permissions.Where(item => item.Family == null).Select(item => new SelectionDescriptedItemInputViewModel<string>
            {
                Id = item.Id,
                Selected = false,
                Label = item.Id,
                Description = item.Description
            }).ToArray(),
            GroupedSelectablePermissions = permissions.Where(item => item.Family != null).GroupBy(item => item.Family).Select(item => new KeyValuePair<string, SelectionDescriptedItemInputViewModel<string>[]>
            (
                item.Key!,
                item.OrderBy(item => item.Id).Select(_item => new SelectionDescriptedItemInputViewModel<string>
                {
                    Id = _item.Id,
                    Selected = false,
                    Label = _item.Id,
                    Description = _item.Description
                }).ToArray()
            )).ToArray()
        };
    }

    protected override async Task ConfigureViewModelAsync(RoleCreateViewModel model)
    {
        PermissionDetailDto[] permissions = await mediator.Send(new PermissionListQuery());

        model.UngroupedSelectablePermissions = permissions.Where(item => item.Family == null).Select(item => new SelectionDescriptedItemInputViewModel<string>
        {
            Id = item.Id,
            Selected = model.SelectedPermissions.Any(_item => _item.Id.Equals(item.Id)),
            Label = item.Id,
            Description = item.Description
        }).ToArray();
        model.GroupedSelectablePermissions = permissions.Where(item => item.Family != null).GroupBy(item => item.Family).Select(item => new KeyValuePair<string, SelectionDescriptedItemInputViewModel<string>[]>
        (
            item.Key!,
            item.OrderBy(item => item.Id).Select(_item => new SelectionDescriptedItemInputViewModel<string>
            {
                Id = _item.Id,
                Selected = model.SelectedPermissions.Any(__item => __item.Id.Equals(_item.Id)),
                Label = _item.Id,
                Description = _item.Description
            }).ToArray()
        )).ToArray();
    }

    protected override async Task ConfigureViewModelAsync(RoleUpdateViewModel model)
    {
        PermissionDetailDto[] permissions = await mediator.Send(new PermissionListQuery());

        model.UngroupedSelectablePermissions = permissions.Where(item => item.Family == null).Select(item => new SelectionDescriptedItemInputViewModel<string>
        {
            Id = item.Id,
            Selected = model.SelectedPermissions.Any(_item => _item.Id.Equals(item.Id)),
            Label = item.Id,
            Description = item.Description
        }).ToArray();
        model.GroupedSelectablePermissions = permissions.Where(item => item.Family != null).GroupBy(item => item.Family).Select(item => new KeyValuePair<string, SelectionDescriptedItemInputViewModel<string>[]>
        (
            item.Key!,
            item.OrderBy(item => item.Id).Select(_item => new SelectionDescriptedItemInputViewModel<string>
            {
                Id = _item.Id,
                Selected = model.SelectedPermissions.Any(__item => __item.Id.Equals(_item.Id)),
                Label = _item.Id,
                Description = _item.Description
            }).ToArray()
        )).ToArray();
    }
}
