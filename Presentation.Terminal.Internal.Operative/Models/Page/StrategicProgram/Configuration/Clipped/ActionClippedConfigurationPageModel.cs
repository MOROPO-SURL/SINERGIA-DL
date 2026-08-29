using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Compoused.StrategicProgram;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram.Configuration.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram.Detail.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration.Clipped;

public sealed class ActionClippedConfigurationPageModel : AbstractConfigurationPageModel<ActionDetailDtoModel, ActionConfigurationResultCompousedModel>
{
    public static string TitleValidableProperty => nameof(Title);
    public static string DescriptionValidableProperty => nameof(Description);

    private string title = null!;
    private int priority = 1;
    private string? description;

    private readonly List<ActionIndicatorCreateClippedRequestModel> inIndicators = [];
    private readonly List<ActionIndicatorUpdateClippedRequestModel> patchIndicators = [];
    private readonly List<ActionIndicatorDetailDtoModel> outIndicators = [];

    public ActionClippedConfigurationPageModel(
        ActionDetailDtoModel? model, 
        Action<ActionConfigurationResultCompousedModel> successCallbackAction, 
        IValidator validator, 
        IEnumerable<ActionIndicatorCreateClippedRequestModel>? inIndicators = null,
        IEnumerable<ActionIndicatorUpdateClippedRequestModel>? patchIndicators = null,
        IEnumerable<ActionIndicatorDetailDtoModel>? outIndicators = null) 
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
                        await Application.Current!.MainPage!.NavigationPushPageAsync(new IndicatorClippedConfigurationPage(new IndicatorClippedConfigurationPageModel(null, task.Result.Items, IndicatorCreateSuccess_Callback, new StrategicProgramActionIndicatorConfigurationValidator())));

                        return;
                    }

                    HandleException(task.Exception);
                });
            });
        });

        UpdateIndicatorCommand = new Command<ActionIndicatorDetailDtoModel>(async model =>
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
                        await Application.Current!.MainPage!.NavigationPushPageAsync(new IndicatorClippedConfigurationPage(new IndicatorClippedConfigurationPageModel(model, task.Result.Items, IndicatorModifySuccess_Callback, new StrategicProgramActionIndicatorConfigurationValidator())));

                        return;
                    }

                    HandleException(task.Exception);
                });
            });
        });

        DeleteIndicatorCommand = new Command<ActionIndicatorDetailDtoModel>(model =>
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

        DetailIndicatorCommand = new Command<ActionIndicatorDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new IndicatorClippedDetailPage(model));
        });

        #endregion

        if (inIndicators != null) this.inIndicators = [.. inIndicators];
        if (patchIndicators != null) this.patchIndicators = [.. patchIndicators];
        if (outIndicators != null) this.outIndicators = [.. outIndicators];

        if (model == null) return;

        Id = model.Id;
        title = model.Title;
        priority = model.Priority;
        description = model.Description;

        Indicators = [.. model.Indicators];
    }

    protected override bool PresentChangeNotification => false;

    protected override Task<ActionConfigurationResultCompousedModel> PerformCreationAsync()
    {
        Guid id = Guid.NewGuid();

        return Task.FromResult(new ActionConfigurationResultCompousedModel(
            new ActionDetailDtoModel(id, title, priority, [.. Indicators], description),
            new ActionUpdateClippedRequestModel(id, title, priority, inIndicators, [], [], description)));
    }

    protected override Task<ActionConfigurationResultCompousedModel> PerformEditionAsync()
    {
        return Task.FromResult(new ActionConfigurationResultCompousedModel(
            new ActionDetailDtoModel(Id!.Value, title, priority, [.. Indicators], description),
            new ActionUpdateClippedRequestModel(Id!.Value, title, priority, inIndicators, patchIndicators, outIndicators, description)));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<ActionClippedConfigurationPageModel>(this);

    public Guid? Id { get; set; }

    public string Title { get => title; set => SetProperty(ref title, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    public ObservableCollection<ActionIndicatorDetailDtoModel> Indicators { get; init; } = [];

    public ICommand CreateIndicatorCommand { get; init; }

    public ICommand UpdateIndicatorCommand { get; init; }

    public ICommand DeleteIndicatorCommand { get; init; }

    public ICommand DetailIndicatorCommand { get; init; }

    private void IndicatorCreateSuccess_Callback(IndicatorConfigurationResultCompousedModel model)
    {
        inIndicators.Add(new ActionIndicatorCreateClippedRequestModel(model.UpdateRequest.Id, model.UpdateRequest.Name, model.UpdateRequest.UnitMeasurement, model.UpdateRequest.Priority, model.UpdateRequest.InMilestones, model.UpdateRequest.Alias));

        // TODO Order list !!!
        Indicators.Add(model.Detail);

        hasChangesFlag = true;
    }

    private void IndicatorModifySuccess_Callback(IndicatorConfigurationResultCompousedModel model)
    {
        bool handled = false;

        foreach (var item in inIndicators)
        {
            if (item.Id != model.UpdateRequest.Id) continue;

            inIndicators.Remove(item);

            inIndicators.Add(new ActionIndicatorCreateClippedRequestModel(model.UpdateRequest.Id, model.UpdateRequest.Name, model.UpdateRequest.UnitMeasurement, model.UpdateRequest.Priority, model.UpdateRequest.InMilestones, model.UpdateRequest.Alias));

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
