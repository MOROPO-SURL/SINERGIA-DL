namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;

public class BaseBindingContextedContentPage<TPageModel> : BaseContentPage where TPageModel : Models.Page.Bases.BasePageModel
{
    public BaseBindingContextedContentPage(TPageModel pageModel)
    {
        BindingContext = pageModel;
    }

    public TPageModel ConcreteBindingContext { get => (TPageModel)BindingContext; }
}
