using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.TerritoryPotentials;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Diagnostic;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/[controller]")]
[Area("diagnostic")]
public class TerritoryPotentialsController : AbstractBaseAdministrationArchivableController<
    TerritoryPotential,
    TerritoryPotentialId,
    Guid,
    TerritoryPotentialBasicViewModel,
    TerritoryPotentialDetailViewModel,
    TerritoryPotentialBasicDto,
    TerritoryPotentialDetailDto,
    TerritoryPotentialPaginateQuery,
    TerritoryPotentialDetailQuery,
    TerritoryPotentialRemoveCommand,
    TerritoryPotentialArchiveCommand,
    TerritoryPotentialUnarchiveCommand>
{
    public TerritoryPotentialsController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }
}
