using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.UI.Pages.Bases
{
    public class BaseDetailBaseContentPage<TModel> : BaseContentPage
    {
        public BaseDetailBaseContentPage(TModel bindingContextModel)
        {
            BindingContext = bindingContextModel;
        }

        protected override bool OnBackButtonPressed()
        {
            DismissControl_Invoked(this, EventArgs.Empty);

            return true;
        }

        protected void DismissControl_Invoked(object sender, EventArgs eventArgs)
        {
            this.NavigationPopModalPageAsync();
        }
    }
}
