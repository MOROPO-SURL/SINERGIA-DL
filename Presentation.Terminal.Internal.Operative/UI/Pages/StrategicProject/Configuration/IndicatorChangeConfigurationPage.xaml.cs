using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProject.Configuration;

public partial class IndicatorChangeConfigurationPage : BaseConfigurationEntityPage<IndicatorChangeDetailDtoModel, IndicatorChangeDetailDtoModel, IndicatorChangeConfigurationPageModel>
{
    public IndicatorChangeConfigurationPage(IndicatorChangeConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Actualización de indicador";
}