using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Configuration;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.Configuration;

public partial class ObjectiveProjectionConfigurationPage : BaseConfigurationEntityPage<ObjectiveProjectionDetailDtoModel, ObjectiveProjectionDetailDtoModel, ObjectiveProjectionConfigurationPageModel>
{
    public ObjectiveProjectionConfigurationPage(ObjectiveProjectionConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Proyección";
}