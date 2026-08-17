using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProjectIdea.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Bases;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.View;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;
using System.Collections.ObjectModel;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page;

public sealed class StrategySummaryPageModel : BasePageModel
{
    private DateTime loadedAt;

    public DateTime LoadedAt { get => loadedAt; set => SetProperty(ref loadedAt, value); }

    public ObservableCollection<DeepStrategicLineViewModel> Lines { get; private set; } = [];

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
            StrategicProjectIdeaQueryApiClient strategicProjectIdeaApiClient = new(httpClientProvider);
            StrategicProjectQueryApiClient strategicProjectApiClient = new(httpClientProvider);

            StrategicAxeDetailDtoModel[] axes = await strategicAxeQueryApiClient.GetAllAsync();
            StrategicLineDetailDtoModel[] lines = [.. (await strategicLineApiClient.GetAllAsync())];
            StrategicProgramDetailDtoModel[] programs = await strategicProgramApiClient.GetAllAsync();
            StrategicProjectIdeaDetailDtoModel[] ideas = await strategicProjectIdeaApiClient.GetAllAsync();
            StrategicProjectDetailDtoModel[] projects = await strategicProjectApiClient.GetAllAsync();

            StrategicLineDetailDtoModel[] axedlines = [.. lines.Where(item => item.Axe != null)];
            StrategicLineDetailDtoModel[] nonaxedlines = [.. lines.Where(item => item.Axe == null)];

            List<DeepStrategicLineViewModel> deepLines = [];

            foreach (StrategicAxeDetailDtoModel axe in axes)
            {
                StrategicLineDetailDtoModel[] axeLines = [.. axedlines.Where(item => item.Axe!.Id == axe.Id)];

                foreach (StrategicLineDetailDtoModel line in axeLines)
                {
                    List<DeepStrategicProgramViewModel> deepPrograms = [];

                    StrategicProgramDetailDtoModel[] linePrograms = [.. programs.Where(item => item.Line.Id == line.Id)];

                    foreach (StrategicProgramDetailDtoModel program in linePrograms)
                    {
                        deepPrograms.Add(new DeepStrategicProgramViewModel(program, ideas.Where(item => item.Program.Id == program.Id), projects.Where(item => item.Program.Id == program.Id)));
                    }

                    deepLines.Add(new DeepStrategicLineViewModel(line, deepPrograms));
                }
            }

            foreach (StrategicLineDetailDtoModel line in nonaxedlines)
            {
                List<DeepStrategicProgramViewModel> deepPrograms = [];

                StrategicProgramDetailDtoModel[] linePrograms = [.. programs.Where(item => item.Line.Id == line.Id)];

                foreach (StrategicProgramDetailDtoModel program in linePrograms)
                {
                    deepPrograms.Add(new DeepStrategicProgramViewModel(program, ideas.Where(item => item.Program.Id == program.Id), projects.Where(item => item.Program.Id == program.Id)));
                }

                deepLines.Add(new DeepStrategicLineViewModel(line, deepPrograms));
            }

            Dispatcher.Dispatch(() =>
            {
                LoadedAt = DateTime.Now;

                Lines.Clear();

                foreach (DeepStrategicLineViewModel item in deepLines)
                {
                    Lines.Add(item);
                }
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
