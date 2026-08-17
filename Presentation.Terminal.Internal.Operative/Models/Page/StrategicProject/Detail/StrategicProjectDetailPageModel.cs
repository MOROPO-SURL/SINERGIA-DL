using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProject.Detail.Clipped;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Detail;

public sealed class StrategicProjectDetailPageModel : AbstractDetailEntityPageModel<StrategicProjectDetailDtoModel>
{
    public StrategicProjectDetailPageModel(StrategicProjectDetailDtoModel model, Action? changeCallbackAction = null) : base(model, changeCallbackAction)
    {
        DetailSpecificObjectiveCommand = new Command<SpecificObjectiveProjectDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new SpecificObjectiveProjectClippedDetailPage(model));
        });

        DetailIndicatorCommand = new Command<IndicatorDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new IndicatorProjectClippedDetailPage(model));
        });
    }

    public ICommand DetailSpecificObjectiveCommand { get; init; }

    public ICommand DetailIndicatorCommand { get; init; }

    protected override async Task PerformRemotionAsync(StrategicProjectDetailDtoModel model)
    {
        StrategicProjectCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        await apiClient.ArchiveAsync(model.Id);
    }
}