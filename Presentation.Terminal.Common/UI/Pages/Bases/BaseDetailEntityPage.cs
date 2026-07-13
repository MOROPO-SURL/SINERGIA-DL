using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

public class BaseDetailEntityPage<TModel, TDetailPageModel> : BaseContentPage
    where TDetailPageModel : AbstractDetailEntityPageModel<TModel>
{
    public BaseDetailEntityPage(TDetailPageModel bindingContextModel)
    {
        BindingContext = bindingContextModel;
    }

    protected TDetailPageModel ConcreteBindingContext => (TDetailPageModel)BindingContext;
}
