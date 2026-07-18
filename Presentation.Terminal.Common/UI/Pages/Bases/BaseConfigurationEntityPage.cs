using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

public class BaseConfigurationEntityPage<TInModel, TOutModel, TConfigurationPageModel> : BaseContentPage
    where TConfigurationPageModel : AbstractConfigurationPageModel<TInModel, TOutModel>
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
