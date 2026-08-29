using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicProjects;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Management.EDL;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/projects")]
[Area("edl")]
public sealed class StrategicProjectsController : AbstractBaseAdministrationArchivableEnableableController<
    StrategicProject,
    StrategicProjectId,
    Guid,
    StrategicProjectBasicViewModel,
    StrategicProjectDetailViewModel,
    StrategicProjectBasicDto,
    StrategicProjectDetailDto,
    StrategicProjectPaginateQuery,
    StrategicProjectDetailQuery,
    StrategicProjectRemoveCommand,
    StrategicProjectArchiveCommand,
    StrategicProjectUnarchiveCommand,
    StrategicProjectEnableCommand,
    StrategicProjectDisableCommand>
{
    public StrategicProjectsController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }
}