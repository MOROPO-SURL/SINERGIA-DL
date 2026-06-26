using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Common.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Common.Configuration;

public partial class PhoneNumberConfigurationPage : BaseConfigurationEntityPage<PhoneNumberDetailDtoModel, PhoneNumberDetailDtoModel, PhoneNumberConfigurationPageModel>
{
    public PhoneNumberConfigurationPage(PhoneNumberConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Teléfono";
}