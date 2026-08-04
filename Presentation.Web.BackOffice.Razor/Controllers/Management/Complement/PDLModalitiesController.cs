using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PDLModalityAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.PDLModalities;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Complement;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/[controller]")]
[Area("complement")]
public class PDLModalitiesController : Abstractions.AbstractBaseManagementController<PDLModality, PDLModalityId, Guid, PDLModalityBasicViewModel, PDLModalityDetailViewModel, PDLModalityCreateViewModel, PDLModalityUpdateViewModel, PDLModalityBasicDto, PDLModalityDetailDto, PDLModalityPaginateQuery, PDLModalityDetailQuery, PDLModalityCreateCommand, PDLModalityUpdateCommand, PDLModalityRemoveCommand>
{
    public PDLModalitiesController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }

    protected override Task<PDLModalityCreateViewModel> BuildCreateViewModelAsync()
    {
        return Task.FromResult(new PDLModalityCreateViewModel());
    }
}