using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.InterestAreas;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Complement;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/[controller]")]
[Area("complement")]
public class InterestAreasController : AbstractBaseAdministrationArchivableEnableableController<
    InterestArea,
    InterestAreaId,
    Guid,
    InterestAreaBasicViewModel,
    InterestAreaDetailViewModel,
    InterestAreaBasicDto,
    InterestAreaDetailDto,
    InterestAreaPaginateQuery,
    InterestAreaDetailQuery,
    InterestAreaRemoveCommand,
    InterestAreaArchiveCommand,
    InterestAreaUnarchiveCommand,
    InterestAreaEnableCommand,
    InterestAreaDisableCommand>
{
    public InterestAreasController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }
}