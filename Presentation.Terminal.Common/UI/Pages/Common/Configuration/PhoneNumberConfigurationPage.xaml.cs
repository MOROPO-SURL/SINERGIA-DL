using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Common.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Common.Configuration;

public partial class PhoneNumberConfigurationPage : BaseConfigurationEntityPage<PhoneNumberDetailDtoModel, PhoneNumberDetailDtoModel, PhoneNumberConfigurationPageModel>
{
    public PhoneNumberConfigurationPage(PhoneNumberConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Teléfono";
}