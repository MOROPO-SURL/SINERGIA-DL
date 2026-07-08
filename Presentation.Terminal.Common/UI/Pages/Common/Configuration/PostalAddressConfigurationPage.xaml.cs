using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Common.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Common.Configuration;

public partial class PostalAddressConfigurationPage : BaseConfigurationEntityPage<PostalAddressDetailDtoModel, PostalAddressDetailDtoModel, PostalAddressConfigurationPageModel>
{
    public PostalAddressConfigurationPage(PostalAddressConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Dirección postal";
}