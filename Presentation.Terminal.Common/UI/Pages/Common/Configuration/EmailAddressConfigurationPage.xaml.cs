using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Common.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Common.Configuration;

public partial class EmailAddressConfigurationPage : BaseConfigurationEntityPage<EmailAddressDetailDtoModel, EmailAddressDetailDtoModel, EmailAddressConfigurationPageModel>
{
    public EmailAddressConfigurationPage(EmailAddressConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Correo electrónico";
}