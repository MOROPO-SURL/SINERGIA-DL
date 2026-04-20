namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases;


/* Cambio no fusionado mediante combinación del proyecto 'Presentation.Terminal.Common (net8.0-android)'
Antes:
public class BaseBindingContextedContentPage<TPageModel> : BaseContentPage where TPageModel : Models.Page.BasePageModel
Después:
public class BaseBindingContextedContentPage<TPageModel> : BaseContentPage where TPageModel : BasePageModel
*/
public class BaseBindingContextedContentPage<TPageModel> : BaseContentPage where TPageModel : Models.Page.Bases.BasePageModel
{
    public BaseBindingContextedContentPage(TPageModel pageModel)
    {
        BindingContext = pageModel;
    }

    public TPageModel ConcreteBindingContext { get => (TPageModel)BindingContext; }
}
