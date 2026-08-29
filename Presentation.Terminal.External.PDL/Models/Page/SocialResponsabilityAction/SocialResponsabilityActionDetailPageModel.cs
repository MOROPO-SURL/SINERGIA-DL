using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.SocialResponsabilityAction.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Locati0n.Detail;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page.SocialResponsabilityAction;

public sealed class SocialResponsabilityActionDetailPageModel : AbstractDetailEntityPageModel<PDLSocialResponsabilityActionDetailDtoModel>
{
    public SocialResponsabilityActionDetailPageModel(PDLSocialResponsabilityActionDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
        DetailLocationCommand = new Command<LocationDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new LocationDetailPage(model));
        });
    }

    public ICommand DetailLocationCommand { get; init; }

    protected override Task PerformRemotionAsync(PDLSocialResponsabilityActionDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}