using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicProjectKinds;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Complement;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/[controller]")]
[Area("complement")]
public class StrategicProjectKindsController : Abstractions.AbstractBaseManagementController<StrategicProjectKind, StrategicProjectKindId, Guid, StrategicProjectKindBasicViewModel, StrategicProjectKindDetailViewModel, StrategicProjectKindCreateViewModel, StrategicProjectKindUpdateViewModel, StrategicProjectKindBasicDto, StrategicProjectKindDetailDto, StrategicProjectKindPaginateQuery, StrategicProjectKindDetailQuery, StrategicProjectKindCreateCommand, StrategicProjectKindUpdateCommand, StrategicProjectKindRemoveCommand>
{
    public StrategicProjectKindsController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }

    protected override Task<StrategicProjectKindCreateViewModel> BuildCreateViewModelAsync()
    {
        return Task.FromResult(new StrategicProjectKindCreateViewModel());
    }
}