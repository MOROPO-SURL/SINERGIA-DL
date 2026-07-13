using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicLine.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicLine.Configuration;

public partial class StrategicLineSpecificObjectiveConfigurationPage : BaseConfigurationEntityPage<StrategicLineSpecificObjectiveDetailDtoModel, StrategicLineSpecificObjectiveDetailDtoModel, StrategicLineSpecificObjectiveConfigurationPageModel>
{
    public StrategicLineSpecificObjectiveConfigurationPage(StrategicLineSpecificObjectiveConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Objetivo específico";
}