using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View.PublicPolicies;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Diagnostic;

[Route("management/[area]/[controller]")]
[Area("diagnostic")]
public class PublicPoliciesController : AbstractBaseAdministrationArchivableController<
    PublicPolicy,
    PublicPolicyId,
    Guid,
    PublicPolicyBasicViewModel,
    PublicPolicyDetailViewModel,
    PublicPolicyBasicDto,
    PublicPolicyDetailDto,
    PublicPolicyPaginateQuery,
    PublicPolicyDetailQuery,
    PublicPolicyRemoveCommand,
    PublicPolicyArchiveCommand,
    PublicPolicyUnarchiveCommand>
{
    public PublicPoliciesController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }
}