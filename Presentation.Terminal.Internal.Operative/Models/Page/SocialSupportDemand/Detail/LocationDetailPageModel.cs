using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.SocialSupportDemand.Detail;

public sealed class LocationDetailPageModel : AbstractDetailEntityPageModel<LocationDetailDtoModel>
{
    public LocationDetailPageModel(LocationDetailDtoModel model, ImageCreateRequestModel? featureImageCreateRequest = null, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
        FeatureImageSource = featureImageCreateRequest?.ToImageSource() ?? model.FeatureImage?.ToImageSource() ?? null;
    }

    public ImageSource? FeatureImageSource { get; init; }

    protected override Task PerformRemotionAsync(LocationDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}
