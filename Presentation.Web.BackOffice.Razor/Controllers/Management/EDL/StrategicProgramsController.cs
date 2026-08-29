using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicPrograms;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Management.EDL;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/programs")]
[Area("edl")]
public sealed class StrategicProgramsController : AbstractBaseAdministrationArchivableEnableableController<
    StrategicProgram,
    StrategicProgramId,
    Guid,
    StrategicProgramBasicViewModel,
    StrategicProgramDetailViewModel,
    StrategicProgramBasicDto,
    StrategicProgramDetailDto,
    StrategicProgramPaginateQuery,
    StrategicProgramDetailQuery,
    StrategicProgramRemoveCommand,
    StrategicProgramArchiveCommand,
    StrategicProgramUnarchiveCommand,
    StrategicProgramEnableCommand,
    StrategicProgramDisableCommand>
{
    public StrategicProgramsController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }
}