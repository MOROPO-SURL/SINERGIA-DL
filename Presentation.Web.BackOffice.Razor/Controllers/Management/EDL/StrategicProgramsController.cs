using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.StrategicPrograms;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Management.EDL;

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