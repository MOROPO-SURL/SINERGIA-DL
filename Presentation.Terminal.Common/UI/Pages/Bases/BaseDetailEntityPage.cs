using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases
{
    public class BaseDetailEntityPage<TModel, TDetailPageModel> : BaseContentPage
        where TDetailPageModel : AbstractDetailEntityPageModel<TModel>
    {
        public BaseDetailEntityPage(TDetailPageModel bindingContextModel)
        {
            BindingContext = bindingContextModel;
        }

        protected TDetailPageModel ConcreteBindingContext => (TDetailPageModel)BindingContext;
    }
}
