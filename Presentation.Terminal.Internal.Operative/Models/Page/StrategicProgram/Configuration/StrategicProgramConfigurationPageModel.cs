using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Compoused.StrategicProgram;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Macroprogram;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Organization;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram.Configuration.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram.Detail.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration;

public sealed class StrategicProgramConfigurationPageModel : AbstractConfigurationPageModel<StrategicProgramDetailDtoModel, StrategicProgramDetailDtoModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string LineValidableProperty => nameof(Line);
    public static string CoordinatorValidableProperty => nameof(Coordinator);
    public static string ObjectiveValidableProperty => nameof(Objective);
    public static string DescriptionValidableProperty => nameof(Description);

    private StrategicLineBasicDtoModel line = null!;
    private string name = null!;
    private PersonBasicDtoModel coordinator = null!;
    private string objective = null!;
    private string? description;
    private int priority = 1;

    private readonly List<SpecificObjectiveCreateClippedRequestModel> inSpecificObjectives = [];
    private readonly List<SpecificObjectiveUpdateClippedRequestModel> patchSpecificObjectives = [];
    private readonly List<GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs.SpecificObjectiveDetailDtoModel> outSpecificObjectives = [];

    private readonly List<ImpactCreateClippedRequestModel> inImpacts = [];
    private readonly List<ImpactUpdateClippedRequestModel> patchImpacts = [];
    private readonly List<ImpactDetailDtoModel> outImpacts = [];

    private readonly List<ActionCreateClippedRequestModel> inActions = [];
    private readonly List<ActionUpdateClippedRequestModel> patchActions = [];
    private readonly List<ActionDetailDtoModel> outActions = [];

    private readonly List<OrganizationBasicDtoModel> inOrganizations = [];
    private readonly List<OrganizationBasicDtoModel> outOrganizations = [];

    private readonly List<MacroprogramBasicDtoModel> inMacroprograms = [];
    private readonly List<MacroprogramBasicDtoModel> outMacroprograms = [];

    public StrategicProgramConfigurationPageModel(StrategicProgramDetailDtoModel? model, StrategicLineBasicDtoModel[] availableLines, Action<StrategicProgramDetailDtoModel> successActionCallback) : base(model, successActionCallback, new StrategicProgramConfigurationValidator())
    {
        AvailableLines = availableLines;

        #region Commands

        #region SpecificObjectives

        CreateSpecificObjectiveCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new SpecificObjectiveClippedConfigurationPage(new SpecificObjectiveClippedConfigurationPageModel(null, SpecificObjectiveCreateSuccess_Callback, new StrategicProgramSpecificObjectiveConfigurationValidator(this))));
        });

        UpdateSpecificObjectiveCommand = new Command<GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs.SpecificObjectiveDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new SpecificObjectiveClippedConfigurationPage(new SpecificObjectiveClippedConfigurationPageModel(model, SpecificObjectiveModifySuccess_Callback, new StrategicProgramSpecificObjectiveConfigurationValidator(this))));
        });

        DeleteSpecificObjectiveCommand = new Command<GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs.SpecificObjectiveDetailDtoModel>(model =>
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

        DetailSpecificObjectiveCommand = new Command<GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs.SpecificObjectiveDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new SpecificObjectiveClippedDetailPage(model));
        });

        #endregion

        #region Impacts

        CreateImpactCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new ImpactClippedConfigurationPage(new ImpactClippedConfigurationPageModel(null, ImpactCreateSuccess_Callback, new StrategicProgramImpactConfigurationValidator())));
        });

        UpdateImpactCommand = new Command<ImpactDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new ImpactClippedConfigurationPage(new ImpactClippedConfigurationPageModel(model, ImpactModifySuccess_Callback, new StrategicProgramImpactConfigurationValidator())));
        });

        DeleteImpactCommand = new Command<ImpactDetailDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inImpacts)
                {
                    if (item.Id != model.Id) continue;

                    inImpacts.Remove(inImpacts.First(item => item.Id == model.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in patchImpacts)
                    {
                        if (item.Id != model.Id) continue;

                        patchImpacts.Remove(patchImpacts.First(item => item.Id == model.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outImpacts.Add(model);
                }

                Dispatcher.Dispatch(() => Impacts.Remove(model));

                hasChangesFlag = true;
            });
        });

        DetailImpactCommand = new Command<ImpactDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new ImpactClippedDetailPage(model));
        });

        #endregion

        #region Actions

        CreateActionCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new ActionClippedConfigurationPage(new ActionClippedConfigurationPageModel(null, ActionCreateSuccess_Callback, new StrategicProgramActionConfigurationValidator())));
        });

        UpdateActionCommand = new Command<ActionDetailDtoModel>(async model =>
        {
            IEnumerable<ActionIndicatorCreateClippedRequestModel>? inIndicators = null;
            IEnumerable<ActionIndicatorUpdateClippedRequestModel>? patchIndicators = null;
            IEnumerable<ActionIndicatorDetailDtoModel>? outIndicators = null;

            bool handled = false;

            foreach (var item in inActions)
            {
                if (item.Id != model.Id) continue;

                inIndicators = item.Indicators;

                handled = true;

                break;
            }

            if (!handled)
            {
                foreach (var item in patchActions)
                {
                    if (item.Id != model.Id) continue;

                    inIndicators = item.InIndicators;
                    patchIndicators = item.PatchIndicators;
                    outIndicators = item.OutIndicators;

                    break;
                }
            }

            await Application.Current!.MainPage!.NavigationPushPageAsync(new ActionClippedConfigurationPage(new ActionClippedConfigurationPageModel(model, ActionModifySuccess_Callback, new StrategicProgramActionConfigurationValidator(), inIndicators, patchIndicators, outIndicators)));
        });

        DeleteActionCommand = new Command<ActionDetailDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inActions)
                {
                    if (item.Id != model.Id) continue;

                    inActions.Remove(inActions.First(item => item.Id == model.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in patchActions)
                    {
                        if (item.Id != model.Id) continue;

                        patchActions.Remove(patchActions.First(item => item.Id == model.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outActions.Add(model);
                }

                Dispatcher.Dispatch(() => Actions.Remove(model));

                hasChangesFlag = true;
            });
        });

        DetailActionCommand = new Command<ActionDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new ActionClippedDetailPage(model));
        });

        #endregion

        #region Organizations

        AddOrganizationCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new NavigationPage(new OrganizationPickPage(OrganizationPicked_Callback)));
        });

        RemoveOrganizationCommand = new Command<OrganizationBasicDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inOrganizations)
                {
                    if (item.Id != model.Id) continue;

                    inOrganizations.Remove(inOrganizations.First(item => item.Id == model.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outOrganizations.Add(model);
                }

                Dispatcher.Dispatch(() => Organizations.Remove(model));

                hasChangesFlag = true;
            });
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
        line = availableLines.First(item => item == model.Line);
        name = model.Name;
        objective = model.Objective;
        coordinator = model.Coordinator;
        description = model.Description;
        priority = model.Priority;

        SpecificObjectives = [.. model.SpecificObjectives];
        Impacts = [.. model.Impacts];
        Actions = [.. model.Actions];
        Macroprograms = [.. model.Macroprograms];
        Organizations = [.. model.Organizations];
    }

    public Guid Id { get; set; }

    public StrategicLineBasicDtoModel Line { get => line; set => SetProperty(ref line, value); }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public PersonBasicDtoModel Coordinator { get => coordinator; set => SetProperty(ref coordinator, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public string Objective { get => objective; set => SetProperty(ref objective, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    public ObservableCollection<GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs.SpecificObjectiveDetailDtoModel> SpecificObjectives { get; init; } = [];

    public ICommand CreateSpecificObjectiveCommand { get; init; }

    public ICommand UpdateSpecificObjectiveCommand { get; init; }

    public ICommand DeleteSpecificObjectiveCommand { get; init; }

    public ICommand DetailSpecificObjectiveCommand { get; init; }

    public ObservableCollection<ImpactDetailDtoModel> Impacts { get; init; } = [];

    public ICommand CreateImpactCommand { get; init; }

    public ICommand UpdateImpactCommand { get; init; }

    public ICommand DeleteImpactCommand { get; init; }

    public ICommand DetailImpactCommand { get; init; }

    public ObservableCollection<ActionDetailDtoModel> Actions { get; init; } = [];

    public ICommand CreateActionCommand { get; init; }

    public ICommand UpdateActionCommand { get; init; }

    public ICommand DeleteActionCommand { get; init; }

    public ICommand DetailActionCommand { get; init; }

    public ObservableCollection<OrganizationBasicDtoModel> Organizations { get; init; } = [];

    public ICommand AddOrganizationCommand { get; init; }

    public ICommand RemoveOrganizationCommand { get; init; }

    public ObservableCollection<MacroprogramBasicDtoModel> Macroprograms { get; init; } = [];

    public ICommand AddMacroprogramCommand { get; init; }

    public ICommand RemoveMacroprogramCommand { get; init; }

    public StrategicLineBasicDtoModel[] AvailableLines { get; init; }

    protected override Task<StrategicProgramDetailDtoModel> PerformCreationAsync()
    {
        StrategicProgramCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new StrategicProgramCreateRequestModel
            (
                name,
                true,
                line.Id,
                coordinator.Id,
                objective,
                priority,
                [.. inSpecificObjectives],
                [.. inImpacts],
                [.. inActions],
                [.. inOrganizations],
                [.. inMacroprograms],
                description
            ));
    }

    protected override Task<StrategicProgramDetailDtoModel> PerformEditionAsync()
    {
        StrategicProgramCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new StrategicProgramUpdateRequestModel
            (
                Id,
                name,
                line.Id,
                coordinator.Id,
                objective,
                priority,
                true,
                [.. inSpecificObjectives],
                [.. patchSpecificObjectives],
                [.. outSpecificObjectives],
                [.. inImpacts],
                [.. patchImpacts],
                [.. outImpacts],
                [.. inActions],
                [.. patchActions],
                [.. outActions],
                [.. inOrganizations],
                [.. outOrganizations],
                [.. inMacroprograms],
                [.. outMacroprograms],
                description
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<StrategicProgramConfigurationPageModel>(this);

    private void OrganizationPicked_Callback(OrganizationBasicDtoModel model)
    {
        inOrganizations.Add(model);

        Organizations.Add(model);

        hasChangesFlag = true;
    }

    private void MacroprogramPicked_Callback(MacroprogramBasicDtoModel model)
    {
        inMacroprograms.Add(model);

        Macroprograms.Add(model);

        hasChangesFlag = true;
    }

    private void SpecificObjectiveCreateSuccess_Callback(GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs.SpecificObjectiveDetailDtoModel model)
    {
        inSpecificObjectives.Add(new SpecificObjectiveCreateClippedRequestModel(model.Index, model.Content));

        // TODO Order list !!!
        SpecificObjectives.Add(model);

        hasChangesFlag = true;
    }

    private void SpecificObjectiveModifySuccess_Callback(GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs.SpecificObjectiveDetailDtoModel model)
    {
        bool handled = false;

        foreach (var item in inSpecificObjectives)
        {
            if (item.Index != model.Index) continue;

            inSpecificObjectives.Remove(item);

            inSpecificObjectives.Add(new SpecificObjectiveCreateClippedRequestModel(model.Index, model.Content));

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in patchSpecificObjectives)
            {
                if (item.Id != model.Id) continue;

                patchSpecificObjectives.Remove(item);

                patchSpecificObjectives.Add(new SpecificObjectiveUpdateClippedRequestModel(model.Id, model.Index, model.Content));

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            patchSpecificObjectives.Add(new SpecificObjectiveUpdateClippedRequestModel(model.Id, model.Index, model.Content));
        }

        var index = -1;

        // TODO Order list !!!
        foreach (var item in SpecificObjectives)
        {
            index++;

            if (item.Id != model.Id) continue;

            SpecificObjectives[index] = new GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs.SpecificObjectiveDetailDtoModel(model.Id, model.Index, model.Content);

            break;
        }

        hasChangesFlag = true;
    }

    private void ImpactCreateSuccess_Callback(ImpactDetailDtoModel model)
    {
        inImpacts.Add(new ImpactCreateClippedRequestModel(model.Id, model.Name, model.Priority, model.Description));

        // TODO Order list !!!
        Impacts.Add(model);

        hasChangesFlag = true;
    }

    private void ImpactModifySuccess_Callback(ImpactDetailDtoModel model)
    {
        bool handled = false;

        foreach (var item in inImpacts)
        {
            if (item.Id != model.Id) continue;

            inImpacts.Remove(item);

            inImpacts.Add(new ImpactCreateClippedRequestModel(model.Id, model.Name, model.Priority, model.Description));

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in patchImpacts)
            {
                if (item.Id != model.Id) continue;

                patchImpacts.Remove(item);

                patchImpacts.Add(new ImpactUpdateClippedRequestModel(model.Id, model.Name, model.Priority, model.Description));

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            patchImpacts.Add(new ImpactUpdateClippedRequestModel(model.Id, model.Name, model.Priority, model.Description));
        }

        var index = -1;

        // TODO Order list !!!
        foreach (var item in Impacts)
        {
            index++;

            if (item.Id != model.Id) continue;

            Impacts[index] = new ImpactDetailDtoModel(model.Id, model.Name, model.Priority, model.Description);

            break;
        }

        hasChangesFlag = true;
    }

    private void ActionCreateSuccess_Callback(ActionConfigurationResultCompousedModel model)
    {
        inActions.Add(new ActionCreateClippedRequestModel(model.UpdateRequest.Id, model.UpdateRequest.Title, model.UpdateRequest.Priority, model.UpdateRequest.InIndicators, model.UpdateRequest.Description));

        // TODO Order list !!!
        Actions.Add(model.Detail);

        hasChangesFlag = true;
    }

    private void ActionModifySuccess_Callback(ActionConfigurationResultCompousedModel model)
    {
        bool handled = false;

        foreach (var item in inActions)
        {
            if (item.Id != model.UpdateRequest.Id) continue;

            inActions.Remove(item);

            inActions.Add(new ActionCreateClippedRequestModel(model.UpdateRequest.Id, model.UpdateRequest.Title, model.UpdateRequest.Priority, model.UpdateRequest.InIndicators, model.UpdateRequest.Description));

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in patchActions)
            {
                if (item.Id != model.UpdateRequest.Id) continue;

                patchActions.Remove(item);

                patchActions.Add(model.UpdateRequest);

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            patchActions.Add(model.UpdateRequest);
        }

        var index = -1;

        // TODO Order list !!!
        foreach (var item in Actions)
        {
            index++;

            if (item.Id != model.Detail.Id) continue;

            Actions[index] = model.Detail;

            break;
        }

        hasChangesFlag = true;
    }
}