using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.UnitMeasurement.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.UnitMeasurement;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.UnitMeasurement;

public partial class UnitMeasurementConfigurationPage : BaseConfigurationEntityPage<UnitMeasurementBasicDtoModel, UnitMeasurementDetailDtoModel, UnitMeasurementConfigurationPageModel>
{
    public UnitMeasurementConfigurationPage(UnitMeasurementConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Unidad de Medida";
}