using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Location.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Location.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Locati0n.Configuration;

public partial class LocationConfigurationPage : BaseConfigurationEntityPage<LocationUpdateRequestModel, LocationUpdateRequestModel, LocationConfigurationPageModel>
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