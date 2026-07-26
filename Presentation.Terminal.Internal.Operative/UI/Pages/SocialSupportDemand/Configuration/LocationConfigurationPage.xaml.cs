using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.SocialSupportDemand.CQRS.Command.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.SocialSupportDemand.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.SocialSupportDemand.Configuration;

public partial class LocationConfigurationPage : BaseConfigurationEntityPage<LocationUpdateClippedRequestModel, LocationUpdateClippedRequestModel, LocationConfigurationPageModel>
{
	public LocationConfigurationPage(LocationConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Localización";

    private void FeatureImageLayoutTapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        ImagePickPresenter.Instance.BeginImagePickAsync(this, ConcreteBindingContext.FeatureImagePickSuccess_Callback);
    }
}