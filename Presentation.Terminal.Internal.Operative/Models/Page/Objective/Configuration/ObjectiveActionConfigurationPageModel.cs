using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Compoused.Objective;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Objective.Configuration;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.Objective.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Configuration;

public sealed class ObjectiveActionConfigurationPageModel : AbstractConfigurationPageModel<ObjectiveActionDetailDtoModel, ObjectiveActionConfigurationResultCompousedModel>
{
    public static string IndexValidableProperty => nameof(Index);
    public static string TitleValidableProperty => nameof(Title);
    public static string DescriptionValidableProperty => nameof(Description);

    private int index = 1;
    private string title;
    private string? description;

    private readonly List<ObjectiveActionIndicatorCreateRequestModel> inIndicators = [];
    private readonly List<ObjectiveActionIndicatorUpdateRequestModel> patchIndicators = [];
    private readonly List<ObjectiveActionIndicatorDetailDtoModel> outIndicators = [];

    public ObjectiveActionConfigurationPageModel(
        ObjectiveActionDetailDtoModel? model, 
        Action<ObjectiveActionConfigurationResultCompousedModel> successCallbackAction, 
        IValidator validator,
        IEnumerable<ObjectiveActionIndicatorCreateRequestModel>? inIndicators = null,
        IEnumerable<ObjectiveActionIndicatorUpdateRequestModel>? patchIndicators = null,
        IEnumerable<ObjectiveActionIndicatorDetailDtoModel>? outIndicators = null) 
        : base(model, successCallbackAction, validator)
    {
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
                        await Application.Current!.MainPage!.NavigationPushPageAsync(new ObjectiveIndicatorConfigurationPage(new ObjectiveIndicatorConfigurationPageModel(null, task.Result.Items, IndicatorCreateSuccess_Callback, new ObjectiveActionIndicatorConfigurationValidator())));

                        return;
                    }

                    HandleException(task.Exception);
                });
            });
        });

        UpdateIndicatorCommand = new Command<ObjectiveActionIndicatorDetailDtoModel>(async model =>
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
                        await Application.Current!.MainPage!.NavigationPushPageAsync(new ObjectiveIndicatorConfigurationPage(new ObjectiveIndicatorConfigurationPageModel(model, task.Result.Items, IndicatorModifySuccess_Callback, new ObjectiveActionIndicatorConfigurationValidator())));

                        return;
                    }

                    HandleException(task.Exception);
                });
            });
        });

        DeleteIndicatorCommand = new Command<ObjectiveActionIndicatorDetailDtoModel>(model =>
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

        DetailIndicatorCommand = new Command<ObjectiveActionIndicatorDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new ObjectiveIndicatorDetailPage(model));
        });

        #endregion

        if (inIndicators != null) this.inIndicators = [.. inIndicators];
        if (patchIndicators != null) this.patchIndicators = [.. patchIndicators];
        if (outIndicators != null) this.outIndicators = [.. outIndicators];

        if (model == null) return;

        Id = model.Id;
        title = model.Title;
        index = model.Index;
        description = model.Description;

        Indicators = [..model.Indicators];
    }

    protected override bool PresentChangeNotification => false;

    protected override Task<ObjectiveActionConfigurationResultCompousedModel> PerformCreationAsync()
    {
        Guid id = Guid.NewGuid();

        return Task.FromResult(new ObjectiveActionConfigurationResultCompousedModel(
            new ObjectiveActionDetailDtoModel(id, index, title, [.. Indicators], description),
            new ObjectiveActionUpdateRequestModel(id, index, title, inIndicators, [], [], description)));
    }

    protected override Task<ObjectiveActionConfigurationResultCompousedModel> PerformEditionAsync()
    {
        return Task.FromResult(new ObjectiveActionConfigurationResultCompousedModel(
            new ObjectiveActionDetailDtoModel(Id!.Value, index, title, [.. Indicators], description),
            new ObjectiveActionUpdateRequestModel(Id!.Value, index, title, inIndicators, patchIndicators, outIndicators, description)));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<ObjectiveActionConfigurationPageModel>(this);

    public Guid? Id { get; set; }

    public int Index { get => index; set => SetProperty(ref index, value); }

    public string? Title { get => title; set => SetProperty(ref title, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    public ObservableCollection<ObjectiveActionIndicatorDetailDtoModel> Indicators { get; init; } = [];

    public ICommand CreateIndicatorCommand { get; init; }

    public ICommand UpdateIndicatorCommand { get; init; }

    public ICommand DeleteIndicatorCommand { get; init; }

    public ICommand DetailIndicatorCommand { get; init; }

    private void IndicatorCreateSuccess_Callback(ObjectiveIndicatorConfigurationResultCompousedModel model)
    {
        inIndicators.Add(new ObjectiveActionIndicatorCreateRequestModel(model.UpdateRequest.Id, model.UpdateRequest.Name, model.UpdateRequest.UnitMeasurement, model.UpdateRequest.Priority, model.UpdateRequest.InMilestones, model.UpdateRequest.Alias));

        // TODO Order list !!!
        Indicators.Add(model.Detail);

        hasChangesFlag = true;
    }

    private void IndicatorModifySuccess_Callback(ObjectiveIndicatorConfigurationResultCompousedModel model)
    {
        bool handled = false;

        foreach (var item in inIndicators)
        {
            if (item.Id != model.UpdateRequest.Id) continue;

            inIndicators.Remove(item);

            inIndicators.Add(new ObjectiveActionIndicatorCreateRequestModel(model.UpdateRequest.Id, model.UpdateRequest.Name, model.UpdateRequest.UnitMeasurement, model.UpdateRequest.Priority, model.UpdateRequest.InMilestones, model.UpdateRequest.Alias));

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