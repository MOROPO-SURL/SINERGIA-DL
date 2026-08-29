using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Objective.Configuration;

public partial class ObjectiveProjectionConfigurationPage : BaseConfigurationEntityPage<ObjectiveProjectionDetailDtoModel, ObjectiveProjectionDetailDtoModel, ObjectiveProjectionConfigurationPageModel>
{
    public ObjectiveProjectionConfigurationPage(ObjectiveProjectionConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Proyección";
}