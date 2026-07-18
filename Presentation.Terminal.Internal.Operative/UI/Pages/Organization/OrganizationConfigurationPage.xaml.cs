using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Organization;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Organization;

public partial class OrganizationConfigurationPage : BaseConfigurationEntityPage<OrganizationDetailDtoModel, OrganizationDetailDtoModel, OrganizationConfigurationPageModel>
{
    public OrganizationConfigurationPage(OrganizationConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Entidad";

    private void ImageLayoutTapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        ImagePickPresenter.Instance.BeginImagePickAsync(this, ImagePickSuccess_Callback);
    }

    private void ImagePickSuccess_Callback(ImageCreateRequestModel model)
    {
        ConcreteBindingContext.ImageSource = ImageSource.FromStream(() => new MemoryStream(model.ContentData));

        ConcreteBindingContext.SetImagePickedModel(model);
    }
}