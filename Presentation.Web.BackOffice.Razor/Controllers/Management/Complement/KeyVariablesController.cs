using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.KeyVariableAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.KeyVariables;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Complement;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/[controller]")]
[Area("complement")]
public class KeyVariablesController : AbstractBaseAdministrationArchivableController<
    KeyVariable,
    KeyVariableId,
    Guid,
    KeyVariableBasicViewModel,
    KeyVariableDetailViewModel,
    KeyVariableBasicDto,
    KeyVariableDetailDto,
    KeyVariablePaginateQuery,
    KeyVariableDetailQuery,
    KeyVariableRemoveCommand,
    KeyVariableArchiveCommand,
    KeyVariableUnarchiveCommand>
{
    public KeyVariablesController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }
}