using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritoryPotential.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.TerritoryPotential;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.TerritoryPotential;

public partial class TerritoryPotentialConfigurationPage : BaseConfigurationEntityPage<TerritoryPotentialBasicDtoModel, TerritoryPotentialDetailDtoModel, TerritoryPotentialConfigurationPageModel>
{
    public TerritoryPotentialConfigurationPage(TerritoryPotentialConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Potencialidad del territorio";
}