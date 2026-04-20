using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;

public class BaseConfigurationEntityPage<TBasicModel, TDetailModel, TConfigurationPageModel> : BaseContentPage
    where TConfigurationPageModel : AbstractConfigurationPageModel<TDetailModel, TDetailModel>
{
    public BaseConfigurationEntityPage(TConfigurationPageModel bindingContextModel)
    {
        if (bindingContextModel.OnEditionMode)
        {
            Title = $"Modificar {EntityTypeName}";
        }
        else
        {
            Title = $"Agregar {EntityTypeName}";
        }

        BindingContext = bindingContextModel;
    }

    protected virtual string EntityTypeName { get; } = "Elemento";

    public TConfigurationPageModel ConcreteBindingContext => (TConfigurationPageModel)BindingContext;
}
