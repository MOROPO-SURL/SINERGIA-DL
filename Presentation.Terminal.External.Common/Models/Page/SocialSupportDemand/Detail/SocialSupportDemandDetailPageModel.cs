using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Location.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Models.Page.SocialSupportDemand.Detail;

public sealed class SocialSupportDemandDetailPageModel : AbstractDetailEntityPageModel<SocialSupportDemandDetailDtoModel>
{
    public SocialSupportDemandDetailPageModel(SocialSupportDemandDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
        DetailLocationCommand = new Command<LocationDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new UI.Pages.SocialSupportDemand.Detail.LocationDetailPage(model));
        });
    }

    public ICommand DetailLocationCommand { get; init; }

    protected override Task PerformRemotionAsync(SocialSupportDemandDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}
