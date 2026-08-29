using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Pages.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.UI.Presenters.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Objective.Detail;

public partial class ObjectiveDetailPage : BaseDetailEntityPage<ObjectiveDetailDtoModel, ObjectiveDetailPageModel>, IDetailItemPageModelPresenter<ObjectiveDetailDtoModel>
{
	public ObjectiveDetailPage(ObjectiveDetailDtoModel model) : base(new ObjectiveDetailPageModel(model))
	{
		InitializeComponent();

        ConcreteBindingContext.BindPresenter(this);
	}

    public Task PresentItemModifyUserInterfaceAsync(ObjectiveDetailDtoModel model, Action<ObjectiveDetailDtoModel> configurationSuccessCallbackAction)
    {
        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new Configuration.ObjectiveConfigurationPage(new ObjectiveConfigurationPageModel(model, configurationSuccessCallbackAction))));

        return Task.CompletedTask;
    }
}