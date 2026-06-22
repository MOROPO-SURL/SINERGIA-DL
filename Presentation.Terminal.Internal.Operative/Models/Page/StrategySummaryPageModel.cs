using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Bases;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.View;
using System.Collections.ObjectModel;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page;

public sealed class StrategySummaryPageModel : BasePageModel
{
    private DateTime loadedAt;

    public DateTime LoadedAt { get => loadedAt; set => SetProperty(ref loadedAt, value); }

    public ObservableCollection<DeepStrategicAxeViewModel> Axes { get; private set; } = [];

    public void LoadSummary()
    {
        if (IsBusy) return;

        IsBusy = true;

        Task.Run(async () =>
        {
            IHttpClientProviderPort httpClientProvider = IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>();

            StrategicAxeQueryApiClient strategicAxeQueryApiClient = new(httpClientProvider);
            StrategicLineQueryApiClient strategicLineApiClient = new(httpClientProvider);
            StrategicProgramQueryApiClient strategicProgramApiClient = new(httpClientProvider);
            StrategicProjectQueryApiClient strategicProjectApiClient = new(httpClientProvider);

            StrategicAxeDetailDtoModel[] axes = await strategicAxeQueryApiClient.GetAllAsync();
            StrategicLineDetailDtoModel[] lines = [.. (await strategicLineApiClient.GetAllAsync())];
            StrategicProgramDetailDtoModel[] programs = await strategicProgramApiClient.GetAllAsync();
            StrategicProjectDetailDtoModel[] projects = await strategicProjectApiClient.GetAllAsync();

            List<DeepStrategicAxeViewModel> deepAxes = [];

            foreach (StrategicAxeDetailDtoModel axe in axes)
            {
                List<DeepStrategicLineViewModel> deepLines = [];

                StrategicLineDetailDtoModel[] axeLines = [.. lines.Where(item => item.Axe != null && item.Axe!.Id == axe.Id)];

                foreach (StrategicLineDetailDtoModel line in axeLines)
                {
                    List<DeepStrategicProgramViewModel> deepPrograms = [];

                    StrategicProgramDetailDtoModel[] linePrograms = [.. programs.Where(item => item.Line.Id == line.Id)];

                    foreach (StrategicProgramDetailDtoModel program in linePrograms)
                    {
                        deepPrograms.Add(new DeepStrategicProgramViewModel(program, projects.Where(item => item.Program.Id == program.Id)));
                    }

                    deepLines.Add(new DeepStrategicLineViewModel(line, deepPrograms));
                }

                deepAxes.Add(new DeepStrategicAxeViewModel(axe, deepLines));
            }

            Dispatcher.Dispatch(() =>
            {
                LoadedAt = DateTime.Now;

                Axes.Clear();

                foreach (DeepStrategicAxeViewModel item in deepAxes)
                {
                    Axes.Add(item);
                }

                // TODO Cached Axes a s Json file on local storage for offline presentation!!
            });
        }).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.IsFaulted || task.IsCanceled)
                {
                    IPlatformApplication.Current!.Services.GetRequiredService<IExceptionHandlingHelperPort>().HandleException(task.Exception);
                }

                IsBusy = false;
            });
        });
    }
}
