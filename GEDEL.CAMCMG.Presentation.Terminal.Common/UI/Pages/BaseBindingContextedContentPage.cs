namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages;

public class BaseBindingContextedContentPage<TPageModel> : BaseContentPage where TPageModel : Models.Page.BasePageModel
{
    public BaseBindingContextedContentPage(TPageModel pageModel)
    {
        BindingContext = pageModel;
    }

    public TPageModel ConcreteBindingContext { get => (TPageModel)BindingContext; }
}
