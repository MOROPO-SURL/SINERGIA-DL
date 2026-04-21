using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Configuration;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.Configuration;

public partial class ObjectiveChallengeConfigurationPage : BaseConfigurationEntityPage<ObjectiveChallengeDetailDtoModel, ObjectiveChallengeDetailDtoModel, ObjectiveChallengeConfigurationPageModel>
{
    public ObjectiveChallengeConfigurationPage(ObjectiveChallengeConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Reto";
}