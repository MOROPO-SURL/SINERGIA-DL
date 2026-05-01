using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureKindAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.FeatureKinds;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Complement;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/[controller]")]
[Area("complement")]
public class FeatureKindsController : Abstractions.AbstractBaseManagementController<FeatureKind, FeatureKindId, Guid, FeatureKindBasicViewModel, FeatureKindDetailViewModel, FeatureKindCreateViewModel, FeatureKindUpdateViewModel, FeatureKindBasicDto, FeatureKindDetailDto, FeatureKindPaginateQuery, FeatureKindDetailQuery, FeatureKindCreateCommand, FeatureKindUpdateCommand, FeatureKindRemoveCommand>
{
    public FeatureKindsController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }

    protected override Task<FeatureKindCreateViewModel> BuildCreateViewModelAsync()
    {
        return Task.FromResult(new FeatureKindCreateViewModel());
    }
}