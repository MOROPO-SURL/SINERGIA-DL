using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.CQRS.Command.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProjectKind.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Compoused.StrategicProject;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Configuration.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Macroprogram;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProject.Configuration.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProject.Detail.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Configuration;

public sealed class StrategicProjectConfigurationPageModel : AbstractConfigurationPageModel<StrategicProjectDetailDtoModel, StrategicProjectDetailDtoModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string KindValidableProperty => nameof(Kind);
    public static string ProgramValidableProperty => nameof(Program);
    public static string ObjectiveValidableProperty => nameof(Objective);
    public static string DescriptionValidableProperty => nameof(Description);

    private string name = null!;
    private StrategicProjectKindBasicDtoModel kind = null!;
    private StrategicProgramBasicDtoModel program = null!;
    private string objective = null!;
    private string? description;
    private int priority = 1;

    private readonly List<SpecificObjectiveProjectCreateClippedRequestModel> inSpecificObjectives = [];
    private readonly List<SpecificObjectiveProjectUpdateClippedRequestModel> patchSpecificObjectives = [];
    private readonly List<Interop.Contracts.Models.StrategicProject.DTOs.SpecificObjectiveProjectDetailDtoModel> outSpecificObjectives = [];

    private readonly List<IndicatorCreateClippedRequestModel> inIndicators = [];
    private readonly List<IndicatorUpdateClippedRequestModel> patchIndicators = [];
    private readonly List<IndicatorDetailDtoModel> outIndicators = [];

    private readonly List<MacroprogramBasicDtoModel> inMacroprograms = [];
    private readonly List<MacroprogramBasicDtoModel> outMacroprograms = [];

    public StrategicProjectConfigurationPageModel(StrategicProjectDetailDtoModel? model, StrategicProjectKindBasicDtoModel[] availableKinds, StrategicProgramBasicDtoModel[] availablePrograms, Action<StrategicProjectDetailDtoModel> successActionCallback) : base(model, successActionCallback, new StrategicProjectConfigurationValidator())
    {
        AvailableKinds = availableKinds;
        AvailablePrograms = availablePrograms;

        #region Commands

        #region SpecificObjectives

        CreateSpecificObjectiveCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new SpecificObjectiveProjectClippedConfigurationPage(new SpecificObjectiveProjectClippedConfigurationPageModel(null, SpecificObjectiveCreateSuccess_Callback, new StrategicProjectSpecificObjectiveConfigurationValidator(this))));
        });

        UpdateSpecificObjectiveCommand = new Command<Interop.Contracts.Models.StrategicProject.DTOs.SpecificObjectiveProjectDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new SpecificObjectiveProjectClippedConfigurationPage(new SpecificObjectiveProjectClippedConfigurationPageModel(model, SpecificObjectiveModifySuccess_Callback, new StrategicProjectSpecificObjectiveConfigurationValidator(this))));
        });

        DeleteSpecificObjectiveCommand = new Command<Interop.Contracts.Models.StrategicProject.DTOs.SpecificObjectiveProjectDetailDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inSpecificObjectives)
                {
                    if (item.Index != model.Index) continue;

                    inSpecificObjectives.Remove(inSpecificObjectives.First(item => item.Index == model.Index));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in patchSpecificObjectives)
                    {
                        if (item.Index != model.Index) continue;

                        patchSpecificObjectives.Remove(patchSpecificObjectives.First(item => item.Index == model.Index));

                        break;
                    }
                }

                if (!handled)
                {
                    outSpecificObjectives.Add(model);
                }

                Dispatcher.Dispatch(() => SpecificObjectives.Remove(model));

                hasChangesFlag = true;
            });
        });

        DetailSpecificObjectiveCommand = new Command<Interop.Contracts.Models.StrategicProject.DTOs.SpecificObjectiveProjectDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new SpecificObjectiveProjectClippedDetailPage(model));
        });

        #endregion

        #region Indicators

        CreateIndicatorCommand = new Command(async () =>
        {
            IsBusy = true;

            UnitMeasurementQueryApiClient client = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

            await client.GetPageAsync(1, 1000).ContinueWith(task =>
            {
                Dispatcher.Dispatch(async () =>
                {
                    IsBusy = false;

                    if (task.IsCompletedSuccessfully)
                    {
                        await Application.Current!.MainPage!.NavigationPushPageAsync(new IndicatorProjectClippedConfigurationPage(new IndicatorProjectClippedConfigurationPageModel(null, task.Result.Items, IndicatorCreateSuccess_Callback, new StrategicProjectIndicatorConfigurationValidator())));

                        return;
                    }

                    HandleException(task.Exception);
                });
            });
        });

        UpdateIndicatorCommand = new Command<IndicatorDetailDtoModel>(async model =>
        {
            IsBusy = true;

            UnitMeasurementQueryApiClient client = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

            await client.GetPageAsync(1, 1000).ContinueWith(task =>
            {
                Dispatcher.Dispatch(async () =>
                {
                    IsBusy = false;

                    if (task.IsCompletedSuccessfully)
                    {
                        await Application.Current!.MainPage!.NavigationPushPageAsync(new IndicatorProjectClippedConfigurationPage(new IndicatorProjectClippedConfigurationPageModel(model, task.Result.Items, IndicatorModifySuccess_Callback, new StrategicProjectIndicatorConfigurationValidator())));

                        return;
                    }

                    HandleException(task.Exception);
                });
            });
        });

        DeleteIndicatorCommand = new Command<IndicatorDetailDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in this.inIndicators)
                {
                    if (item.Id != model.Id) continue;

                    this.inIndicators.Remove(this.inIndicators.First(item => item.Id == model.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in this.patchIndicators)
                    {
                        if (item.Id != model.Id) continue;

                        this.patchIndicators.Remove(this.patchIndicators.First(item => item.Id == model.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    this.outIndicators.Add(model);
                }

                Dispatcher.Dispatch(() => Indicators.Remove(model));

                hasChangesFlag = true;
            });
        });

        DetailIndicatorCommand = new Command<IndicatorDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new IndicatorProjectClippedDetailPage(model));
        });

        #endregion

        #region Macroprograms

        AddMacroprogramCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new NavigationPage(new MacroprogramPickPage(MacroprogramPicked_Callback)));
        });

        RemoveMacroprogramCommand = new Command<MacroprogramBasicDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inMacroprograms)
                {
                    if (item.Id != model.Id) continue;

                    inMacroprograms.Remove(inMacroprograms.First(item => item.Id == model.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outMacroprograms.Add(model);
                }

                Dispatcher.Dispatch(() => Macroprograms.Remove(model));

                hasChangesFlag = true;
            });
        });

        #endregion

        #endregion

        if (model is null) return;

        Id = model.Id;
        name = model.Name;
        kind = availableKinds.First(item => item == model.Kind);
        program = availablePrograms.First(item => item.Id == model.Program.Id);
        objective = model.Objective;
        description = model.Description;
        priority = model.Priority;

        SpecificObjectives = [.. model.SpecificObjectives];
        Indicators = [.. model.Indicators];
        Macroprograms = [.. model.Macroprograms];
    }

    public Guid Id { get; set; }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public StrategicProjectKindBasicDtoModel Kind { get => kind; set => SetProperty(ref kind, value); }

    public StrategicProgramBasicDtoModel Program { get => program; set => SetProperty(ref program, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public string Objective { get => objective; set => SetProperty(ref objective, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    public ObservableCollection<Interop.Contracts.Models.StrategicProject.DTOs.SpecificObjectiveProjectDetailDtoModel> SpecificObjectives { get; init; } = [];

    public ICommand CreateSpecificObjectiveCommand { get; init; }

    public ICommand UpdateSpecificObjectiveCommand { get; init; }

    public ICommand DeleteSpecificObjectiveCommand { get; init; }

    public ICommand DetailSpecificObjectiveCommand { get; init; }

    public ObservableCollection<IndicatorDetailDtoModel> Indicators { get; init; } = [];

    public ICommand CreateIndicatorCommand { get; init; }

    public ICommand UpdateIndicatorCommand { get; init; }

    public ICommand DeleteIndicatorCommand { get; init; }

    public ICommand DetailIndicatorCommand { get; init; }

    public ObservableCollection<MacroprogramBasicDtoModel> Macroprograms { get; init; } = [];

    public ICommand AddMacroprogramCommand { get; init; }

    public ICommand RemoveMacroprogramCommand { get; init; }


    public StrategicProjectKindBasicDtoModel[] AvailableKinds { get; private set; }

    public StrategicProgramBasicDtoModel[] AvailablePrograms { get; private set; }

    protected override Task<StrategicProjectDetailDtoModel> PerformCreationAsync()
    {
        StrategicProjectCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new StrategicProjectCreateRequestModel
            (
                name,
                kind.Id,
                program.Id,
                priority,
                true,
                objective,
                [.. inSpecificObjectives],
                [.. inIndicators],
                [.. inMacroprograms],
                description
            ));
    }

    protected override Task<StrategicProjectDetailDtoModel> PerformEditionAsync()
    {
        StrategicProjectCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new StrategicProjectUpdateRequestModel
            (
                Id,
                name,
                kind.Id,
                program.Id,
                priority,
                true,
                objective,
                [.. inSpecificObjectives],
                [.. patchSpecificObjectives],
                [.. outSpecificObjectives],
                [.. inIndicators],
                [.. patchIndicators],
                [.. outIndicators],
                [.. inMacroprograms],
                [.. outMacroprograms],
                description
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<StrategicProjectConfigurationPageModel>(this);

    private void MacroprogramPicked_Callback(MacroprogramBasicDtoModel model)
    {
        inMacroprograms.Add(model);

        Macroprograms.Add(model);

        hasChangesFlag = true;
    }

    private void SpecificObjectiveCreateSuccess_Callback(Interop.Contracts.Models.StrategicProject.DTOs.SpecificObjectiveProjectDetailDtoModel model)
    {
        inSpecificObjectives.Add(new SpecificObjectiveProjectCreateClippedRequestModel(model.Index, model.Content));

        // TODO Order list !!!
        SpecificObjectives.Add(model);

        hasChangesFlag = true;
    }

    private void SpecificObjectiveModifySuccess_Callback(Interop.Contracts.Models.StrategicProject.DTOs.SpecificObjectiveProjectDetailDtoModel model)
    {
        bool handled = false;

        foreach (var item in inSpecificObjectives)
        {
            if (item.Index != model.Index) continue;

            inSpecificObjectives.Remove(item);

            inSpecificObjectives.Add(new SpecificObjectiveProjectCreateClippedRequestModel(model.Index, model.Content));

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in patchSpecificObjectives)
            {
                if (item.Id != model.Id) continue;

                patchSpecificObjectives.Remove(item);

                patchSpecificObjectives.Add(new SpecificObjectiveProjectUpdateClippedRequestModel(model.Id, model.Index, model.Content));

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            patchSpecificObjectives.Add(new SpecificObjectiveProjectUpdateClippedRequestModel(model.Id, model.Index, model.Content));
        }

        var index = -1;

        // TODO Order list !!!
        foreach (var item in SpecificObjectives)
        {
            index++;

            if (item.Id != model.Id) continue;

            SpecificObjectives[index] = new Interop.Contracts.Models.StrategicProject.DTOs.SpecificObjectiveProjectDetailDtoModel(model.Id, model.Index, model.Content);

            break;
        }

        hasChangesFlag = true;
    }

    private void IndicatorCreateSuccess_Callback(IndicatorProjectConfigurationResultCompousedModel model)
    {
        inIndicators.Add(new IndicatorCreateClippedRequestModel(model.UpdateRequest.Id, model.UpdateRequest.Name, model.UpdateRequest.UnitMeasurement, model.UpdateRequest.Priority, model.UpdateRequest.InMilestones, model.UpdateRequest.Alias));

        // TODO Order list !!!
        Indicators.Add(model.Detail);

        hasChangesFlag = true;
    }

    private void IndicatorModifySuccess_Callback(IndicatorProjectConfigurationResultCompousedModel model)
    {
        bool handled = false;

        foreach (var item in inIndicators)
        {
            if (item.Id != model.UpdateRequest.Id) continue;

            inIndicators.Remove(item);

            inIndicators.Add(new IndicatorCreateClippedRequestModel(model.UpdateRequest.Id, model.UpdateRequest.Name, model.UpdateRequest.UnitMeasurement, model.UpdateRequest.Priority, model.UpdateRequest.InMilestones, model.UpdateRequest.Alias));

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in patchIndicators)
            {
                if (item.Id != model.UpdateRequest.Id) continue;

                patchIndicators.Remove(item);

                patchIndicators.Add(model.UpdateRequest);

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            patchIndicators.Add(model.UpdateRequest);
        }

        var index = -1;

        // TODO Order list !!!
        foreach (var item in Indicators)
        {
            index++;

            if (item.Id != model.Detail.Id) continue;

            Indicators[index] = model.Detail;

            break;
        }

        hasChangesFlag = true;
    }
}