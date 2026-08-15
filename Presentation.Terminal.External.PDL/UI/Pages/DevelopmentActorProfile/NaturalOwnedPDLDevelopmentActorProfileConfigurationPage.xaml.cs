using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page.DevelopmentActorProfile;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.UI.Pages;

public partial class NaturalOwnedPDLDevelopmentActorProfileConfigurationPage : BaseConfigurationEntityPage<NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel, NaturalOwnedPDLDevelopmentActorProfileDetailDtoModel, NaturalOwnedPDLDevelopmentActorProfileConfigurationPageModel>
{
    public NaturalOwnedPDLDevelopmentActorProfileConfigurationPage(NaturalOwnedPDLDevelopmentActorProfileConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Perfil de Actor de Desarrollo";
}