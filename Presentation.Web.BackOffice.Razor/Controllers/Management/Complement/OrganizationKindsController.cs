using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKinds.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationKindAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.OrganizationKinds;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Complement;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/[controller]")]
[Area("complement")]
public class OrganizationKindsController : Abstractions.AbstractBaseManagementController<OrganizationKind, OrganizationKindId, Guid, OrganizationKindBasicViewModel, OrganizationKindDetailViewModel, OrganizationKindCreateViewModel, OrganizationKindUpdateViewModel, OrganizationKindBasicDto, OrganizationKindDetailDto, OrganizationKindPaginateQuery, OrganizationKindDetailQuery, OrganizationKindCreateCommand, OrganizationKindUpdateCommand, OrganizationKindRemoveCommand>
{
    public OrganizationKindsController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }

    protected override Task<OrganizationKindCreateViewModel> BuildCreateViewModelAsync()
    {
        return Task.FromResult(new OrganizationKindCreateViewModel());
    }
}
