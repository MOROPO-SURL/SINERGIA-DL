using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.Objective.Configuration;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.UI.Pages.Objective.Detail;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Validators;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Configuration;

public sealed class ObjectiveConfigurationPageModel : AbstractConfigurationPageModel<ObjectiveDetailDtoModel, ObjectiveDetailDtoModel>
{
    public static string TitleValidableProperty => nameof(Title);
    public static string DescriptionValidableProperty => nameof(Description);

    private int index = 1;
    private string? title;
    private string? description;

    private readonly List<ObjectiveChallengeCreateRequestModel> inChallanges = [];
    private readonly List<ObjectiveChallengeUpdateRequestModel> patchChallanges = [];
    private readonly List<ObjectiveChallengeDetailDtoModel> outChallanges = [];

    private readonly List<ObjectiveProjectionCreateRequestModel> inProjections = [];
    private readonly List<ObjectiveProjectionUpdateRequestModel> patchProjections = [];
    private readonly List<ObjectiveProjectionDetailDtoModel> outProjections = [];

    private readonly List<ObjectiveActionCreateRequestModel> inActions = [];
    private readonly List<ObjectiveActionUpdateRequestModel> patchActions = [];
    private readonly List<ObjectiveActionDetailDtoModel> outActions = [];

    public ObjectiveConfigurationPageModel(ObjectiveDetailDtoModel? model, Action<ObjectiveDetailDtoModel> successActionCallback) : base(model, successActionCallback, new ObjectiveConfigurationValidator())
    {
        #region Challanges

        CreateChallangeCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new ObjectiveChallengeConfigurationPage(new ObjectiveChallengeConfigurationPageModel(null, ChallangeCreateSuccess_Callback, new ObjectiveChallangeConfigurationValidator(this))));
        });

        UpdateChallangeCommand = new Command<ObjectiveChallengeDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new ObjectiveChallengeConfigurationPage(new ObjectiveChallengeConfigurationPageModel(model, ChallangeModifySuccess_Callback, new ObjectiveChallangeConfigurationValidator(this))));
        });

        DetailChallangeCommand = new Command<ObjectiveChallengeDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new ObjectiveChallengeDetailPage(model));
        });

        RemoveChallangeCommand = new Command<ObjectiveChallengeDetailDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inChallanges)
                {
                    if (item.Id != model.Id) continue;

                    inChallanges.Remove(inChallanges.First(item => item.Id == model.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in patchChallanges)
                    {
                        if (item.Id != model.Id) continue;

                        patchChallanges.Remove(patchChallanges.First(item => item.Id == model.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outChallanges.Add(model);
                }

                Application.Current!.MainPage!.Dispatcher.Dispatch(() => Challanges.Remove(model));

                hasChangesFlag = true;
            });
        });

        #endregion

        #region Projections

        CreateProjectionCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new ObjectiveProjectionConfigurationPage(new ObjectiveProjectionConfigurationPageModel(null, ProjectionCreateSuccess_Callback, new ObjectiveProjectionConfigurationValidator(this))));
        });

        UpdateProjectionCommand = new Command<ObjectiveProjectionDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new ObjectiveProjectionConfigurationPage(new ObjectiveProjectionConfigurationPageModel(model, ProjectionModifySuccess_Callback, new ObjectiveProjectionConfigurationValidator(this))));
        });

        DetailProjectionCommand = new Command<ObjectiveProjectionDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new ObjectiveProjectionDetailPage(model));
        });

        RemoveProjectionCommand = new Command<ObjectiveProjectionDetailDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in inProjections)
                {
                    if (item.Id != model.Id) continue;

                    inProjections.Remove(inProjections.First(item => item.Id == model.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in patchProjections)
                    {
                        if (item.Id != model.Id) continue;

                        patchProjections.Remove(patchProjections.First(item => item.Id == model.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outProjections.Add(model);
                }

                Application.Current!.MainPage!.Dispatcher.Dispatch(() => Projections.Remove(model));

                hasChangesFlag = true;
            });
        });

        #endregion

        #region Actions

        CreateActionCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new ObjectiveActionConfigurationPage(new ObjectiveActionConfigurationPageModel(null, ActionCreateSuccess_Callback, new ObjectiveActionConfigurationValidator(this))));
        });

        UpdateActionCommand = new Command<ObjectiveActionDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new ObjectiveActionConfigurationPage(new ObjectiveActionConfigurationPageModel(model, ActionModifySuccess_Callback, new ObjectiveActionConfigurationValidator(this))));
        });

        DetailActionCommand = new Command<ObjectiveActionDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new ObjectiveActionDetailPage(model));
        });

        RemoveActionCommand = new Command<ObjectiveActionDetailDtoModel>(model =>
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

                Application.Current!.MainPage!.Dispatcher.Dispatch(() => Actions.Remove(model));

                hasChangesFlag = true;
            });
        });

        #endregion

        if (model is null) return;

        Id = model.Id;
        index = model.Index;
        title = model.Title;
        description = model.Description;

        Challanges = [.. model.Challanges];
        Projections = [.. model.Projections];
        Actions = [.. model.Actions];
    }

    public Guid? Id { get; set; }

    public int Index { get => index; set => SetProperty(ref index, value); }

    public string? Title { get => title; set => SetProperty(ref title, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    public ObservableCollection<ObjectiveChallengeDetailDtoModel> Challanges { get; set; } = [];

    public ICommand CreateChallangeCommand { get; private set; }

    public ICommand UpdateChallangeCommand { get; private set; }

    public ICommand DetailChallangeCommand { get; private set; }

    public ICommand RemoveChallangeCommand { get; private set; }

    public ObservableCollection<ObjectiveProjectionDetailDtoModel> Projections { get; set; } = [];

    public ICommand CreateProjectionCommand { get; private set; }

    public ICommand UpdateProjectionCommand { get; private set; }

    public ICommand DetailProjectionCommand { get; private set; }

    public ICommand RemoveProjectionCommand { get; private set; }

    public ObservableCollection<ObjectiveActionDetailDtoModel> Actions { get; set; } = [];

    public ICommand CreateActionCommand { get; private set; }

    public ICommand UpdateActionCommand { get; private set; }

    public ICommand DetailActionCommand { get; private set; }

    public ICommand RemoveActionCommand { get; private set; }

    protected override Task<ObjectiveDetailDtoModel> PerformCreationAsync()
    {
        ObjectiveCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new ObjectiveCreateRequestModel
            (
                Index,
                Title!,
                [.. inChallanges],
                [.. inProjections],
                [.. inActions],
                Description
            ));
    }

    protected override Task<ObjectiveDetailDtoModel> PerformEditionAsync()
    {
        ObjectiveCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new ObjectiveUpdateRequestModel
            (
                Id!.Value,
                Index,
                Title!,
                [.. inChallanges],
                [.. patchChallanges],
                [.. outChallanges],
                [.. inProjections],
                [.. patchProjections],
                [.. outProjections],
                [.. inActions],
                [.. patchActions],
                [.. outActions],
                Description
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<ObjectiveConfigurationPageModel>(this);

    private void ChallangeCreateSuccess_Callback(ObjectiveChallengeDetailDtoModel model)
    {
        inChallanges.Add(new ObjectiveChallengeCreateRequestModel(model.Id, model.Index, model.Title, model.Description));

        // TODO Order list !!!
        Challanges.Add(model);

        hasChangesFlag = true;
    }

    private void ChallangeModifySuccess_Callback(ObjectiveChallengeDetailDtoModel model)
    {
        bool handled = false;

        foreach (var item in inChallanges)
        {
            if (item.Id != model.Id) continue;

            inChallanges.Remove(item);

            inChallanges.Add(new ObjectiveChallengeCreateRequestModel(model.Id, model.Index, model.Title, model.Description));

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in patchChallanges)
            {
                if (item.Id != model.Id) continue;

                patchChallanges.Remove(item);

                patchChallanges.Add(new ObjectiveChallengeUpdateRequestModel(model.Id, model.Index, model.Title, model.Description));

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            patchChallanges.Add(new ObjectiveChallengeUpdateRequestModel(model.Id, model.Index, model.Title, model.Description));
        }

        var index = -1;

        // TODO Order list !!!
        foreach (var item in Challanges)
        {
            index++;

            if (item.Id != model.Id) continue;

            Challanges[index] = new ObjectiveChallengeDetailDtoModel(model.Id, model.Index, model.Title, model.Description);

            break;
        }

        hasChangesFlag = true;
    }

    private void ProjectionCreateSuccess_Callback(ObjectiveProjectionDetailDtoModel model)
    {
        inProjections.Add(new ObjectiveProjectionCreateRequestModel(model.Id, model.Index, model.Title, model.Description));

        // TODO Order list !!!
        Projections.Add(model);

        hasChangesFlag = true;
    }

    private void ProjectionModifySuccess_Callback(ObjectiveProjectionDetailDtoModel model)
    {
        bool handled = false;

        foreach (var item in inProjections)
        {
            if (item.Id != model.Id) continue;

            inProjections.Remove(item);

            inProjections.Add(new ObjectiveProjectionCreateRequestModel(model.Id, model.Index, model.Title, model.Description));

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in patchProjections)
            {
                if (item.Id != model.Id) continue;

                patchProjections.Remove(item);

                patchProjections.Add(new ObjectiveProjectionUpdateRequestModel(model.Id, model.Index, model.Title, model.Description));

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            patchProjections.Add(new ObjectiveProjectionUpdateRequestModel(model.Id, model.Index, model.Title, model.Description));
        }

        var index = -1;

        // TODO Order list !!!
        foreach (var item in Projections)
        {
            index++;

            if (item.Id != model.Id) continue;

            Projections[index] = new ObjectiveProjectionDetailDtoModel(model.Id, model.Index, model.Title, model.Description);

            break;
        }

        hasChangesFlag = true;
    }

    private void ActionCreateSuccess_Callback(ObjectiveActionDetailDtoModel model)
    {
        inActions.Add(new ObjectiveActionCreateRequestModel(model.Id, model.Index, model.Title, model.Description));

        // TODO Order list !!!
        Actions.Add(model);

        hasChangesFlag = true;
    }

    private void ActionModifySuccess_Callback(ObjectiveActionDetailDtoModel model)
    {
        bool handled = false;

        foreach (var item in inActions)
        {
            if (item.Id != model.Id) continue;

            inActions.Remove(item);

            inActions.Add(new ObjectiveActionCreateRequestModel(model.Id, model.Index, model.Title, model.Description));

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in patchActions)
            {
                if (item.Id != model.Id) continue;

                patchActions.Remove(item);

                patchActions.Add(new ObjectiveActionUpdateRequestModel(model.Id, model.Index, model.Title, model.Description));

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            patchActions.Add(new ObjectiveActionUpdateRequestModel(model.Id, model.Index, model.Title, model.Description));
        }

        var index = -1;

        // TODO Order list !!!
        foreach (var item in Actions)
        {
            index++;

            if (item.Id != model.Id) continue;

            Actions[index] = new ObjectiveActionDetailDtoModel(model.Id, model.Index, model.Title, model.Description);

            break;
        }

        hasChangesFlag = true;
    }
}
