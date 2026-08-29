using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.Features;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Controllers.Management.Diagnostic;

[Microsoft.AspNetCore.Authorization.Authorize]
[Route("management/[area]/[controller]")]
[Area("diagnostic")]
public class FeaturesController : AbstractBaseRemotionController<
    Feature,
    FeatureId,
    Guid,
    FeatureBasicViewModel,
    FeatureDetailViewModel,
    FeatureBasicDto,
    FeatureDetailDto,
    FeaturePaginateQuery,
    FeatureDetailQuery,
    FeatureRemoveCommand>
{
    public FeaturesController(IMapper mapper, ISender mediator) : base(mapper, mediator)
    {
    }
}