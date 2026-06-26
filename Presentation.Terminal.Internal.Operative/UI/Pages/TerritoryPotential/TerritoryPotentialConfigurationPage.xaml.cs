using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritoryPotential.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.TerritoryPotential;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.TerritoryPotential;

public partial class TerritoryPotentialConfigurationPage : BaseConfigurationEntityPage<TerritoryPotentialBasicDtoModel, TerritoryPotentialDetailDtoModel, TerritoryPotentialConfigurationPageModel>
{
    public TerritoryPotentialConfigurationPage(TerritoryPotentialConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Potencialidad del territorio";
}