using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Presenters;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Person;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.Person;

public partial class PersonConfigurationPage : BaseConfigurationEntityPage<PersonBasicDtoModel, PersonDetailDtoModel, PersonConfigurationPageModel>
{
    public PersonConfigurationPage(PersonConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Persona";

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