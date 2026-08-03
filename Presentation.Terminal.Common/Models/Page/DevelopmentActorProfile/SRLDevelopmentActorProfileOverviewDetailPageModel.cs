using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Location.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Locati0n.Detail;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.DevelopmentActorProfile;

public sealed class SRLDevelopmentActorProfileOverviewDetailPageModel : AbstractDetailEntityPageModel<SRLDevelopmentActorProfileDetailDtoModel>
{
    public SRLDevelopmentActorProfileOverviewDetailPageModel(SRLDevelopmentActorProfileDetailDtoModel model) : base(model)
    {
        DetailLocationCommand = new Command<LocationDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new LocationDetailPage(model));
        });
    }

    public ICommand DetailLocationCommand { get; init; }

    protected override Task PerformRemotionAsync(SRLDevelopmentActorProfileDetailDtoModel model)
    {
        throw new NotImplementedException();
    }
}
