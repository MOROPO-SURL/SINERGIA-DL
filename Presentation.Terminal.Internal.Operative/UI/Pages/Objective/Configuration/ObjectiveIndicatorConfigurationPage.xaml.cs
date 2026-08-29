using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Compoused.Objective;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Configuration;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Objective.Configuration;

public partial class ObjectiveIndicatorConfigurationPage : BaseConfigurationEntityPage<ObjectiveActionIndicatorDetailDtoModel, ObjectiveIndicatorConfigurationResultCompousedModel, ObjectiveIndicatorConfigurationPageModel>
{
    public ObjectiveIndicatorConfigurationPage(ObjectiveIndicatorConfigurationPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Indicador";
}