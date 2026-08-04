using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page.DevelopmentActorProfile;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.UI.Pages;

public partial class LegalOwnedPDLDevelopmentActorProfileConfigurationPage : BaseConfigurationEntityPage<LegalOwnedPDLDevelopmentActorProfileDetailDtoModel, LegalOwnedPDLDevelopmentActorProfileDetailDtoModel, LegalOwnedPDLDevelopmentActorProfileConfigurationPageModel>
{
    public LegalOwnedPDLDevelopmentActorProfileConfigurationPage(LegalOwnedPDLDevelopmentActorProfileConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Perfil de Actor de Desarrollo";
}