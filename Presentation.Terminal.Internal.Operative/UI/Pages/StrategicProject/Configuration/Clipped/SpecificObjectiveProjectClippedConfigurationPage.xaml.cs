using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Configuration.Clipped;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProject.Configuration.Clipped;

public partial class SpecificObjectiveProjectClippedConfigurationPage : BaseConfigurationEntityPage<SpecificObjectiveProjectDetailDtoModel, SpecificObjectiveProjectDetailDtoModel, SpecificObjectiveProjectClippedConfigurationPageModel>
{
    public SpecificObjectiveProjectClippedConfigurationPage(SpecificObjectiveProjectClippedConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Objetivo específico";
}