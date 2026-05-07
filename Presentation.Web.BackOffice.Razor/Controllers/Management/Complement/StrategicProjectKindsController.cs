using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjectKinds.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicProjectKinds;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Complement;

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