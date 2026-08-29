using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Location.Detail;

public sealed class LocationDetailPageModel : AbstractDetailEntityPageModel<LocationDetailDtoModel>
{
    public LocationDetailPageModel(LocationDetailDtoModel model, ImageCreateRequestModel? featureImageCreateRequest = null, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
        FeatureImageSource = featureImageCreateRequest?.ToImageSource() ?? model?.FeatureImage?.ToImageSource() ?? null;
    }

    public ImageSource? FeatureImageSource { get; init; }

    protected override Task PerformRemotionAsync(LocationDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}
