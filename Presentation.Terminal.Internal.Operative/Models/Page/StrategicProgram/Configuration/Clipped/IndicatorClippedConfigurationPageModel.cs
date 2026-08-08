using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command.Clipped;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.UnitMeasurement.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Compoused.StrategicProgram;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram.Configuration.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.UI.Pages.StrategicProgram.Detail.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration.Clipped;

public sealed class IndicatorClippedConfigurationPageModel : AbstractConfigurationPageModel<ActionIndicatorDetailDtoModel, IndicatorConfigurationResultCompousedModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string AliasValidableProperty => nameof(Alias);
    public static string UnitMeasurementValidableProperty => nameof(UnitMeasurement);
    public static string MilestonesValidableProperty => nameof(Milestones);

    private string name = null!;
    private int priority = 1;
    private string? alias;
    private UnitMeasurementBasicDtoModel unitMeasurement = null!;

    private readonly List<ActionIndicatorMilestoneCreateClippedRequestModel> inMilestones = [];
    private readonly List<ActionIndicatorMilestoneUpdateClippedRequestModel> patchMilestones = [];
    private readonly List<ActionIndicatorMilestoneDetailDtoModel> outMilestones = [];

    protected override bool PresentChangeNotification => false;

    public override IValidationContext? ValidationContext => new ValidationContext<IndicatorClippedConfigurationPageModel>(this);

    public IndicatorClippedConfigurationPageModel(
        ActionIndicatorDetailDtoModel? model, 
        IEnumerable<UnitMeasurementBasicDtoModel> availableUnitmMeasurements, 
        Action<IndicatorConfigurationResultCompousedModel> successCallbackAction, 
        IValidator validator,
        IEnumerable<ActionIndicatorMilestoneCreateClippedRequestModel>? inMilestones = null,
        IEnumerable<ActionIndicatorMilestoneUpdateClippedRequestModel>? patchMilestones = null,
        IEnumerable<ActionIndicatorMilestoneDetailDtoModel>? outMilestones = null) : base(model, successCallbackAction, validator)
    {
        #region Milestones

        CreateMilestoneCommand = new Command(async () =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new MilestoneClippedConfigurationPage(new MilestoneClippedConfigurationPageModel(null, unitMeasurement, MilestoneCreateSuccess_Callback, new StrategicProgramActionIndicatorMilestoneConfigurationValidator())));
        });

        UpdateMilestoneCommand = new Command<ActionIndicatorMilestoneDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushPageAsync(new MilestoneClippedConfigurationPage(new MilestoneClippedConfigurationPageModel(model, unitMeasurement, MilestoneModifySuccess_Callback, new StrategicProgramActionIndicatorMilestoneConfigurationValidator())));
        });

        DeleteMilestoneCommand = new Command<ActionIndicatorMilestoneDetailDtoModel>(model =>
        {
            Application.Current!.MainPage!.DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                bool handled = false;

                foreach (var item in this.inMilestones)
                {
                    if (item.Id != model.Id) continue;

                    this.inMilestones.Remove(this.inMilestones.First(item => item.Id == model.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in this.patchMilestones)
                    {
                        if (item.Id != model.Id) continue;

                        this.patchMilestones.Remove(this.patchMilestones.First(item => item.Id == model.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    this.outMilestones.Add(model);
                }

                Dispatcher.Dispatch(() => Milestones.Remove(model));

                hasChangesFlag = true;
            });
        });

        DetailMilestoneCommand = new Command<ActionIndicatorMilestoneDetailDtoModel>(async model =>
        {
            await Application.Current!.MainPage!.NavigationPushModalPageAsync(new MilestoneClippedDetailPage(model));
        });

        #endregion

        AvailableUnitmMeasurements = [.. availableUnitmMeasurements];

        if (inMilestones != null) this.inMilestones = [.. inMilestones];
        if (patchMilestones != null) this.patchMilestones = [.. patchMilestones];
        if (outMilestones != null) this.outMilestones = [.. outMilestones];

        if (model == null) return;

        Id = model.Id;
        name = model.Name;
        alias = model.Alias;
        unitMeasurement = AvailableUnitmMeasurements.First(item =>  item.Id == model.UnitMeasurement.Id);

        Milestones = [.. model.Milestones];
    }

    protected override Task<IndicatorConfigurationResultCompousedModel> PerformCreationAsync()
    {
        Guid id = Guid.NewGuid();

        return Task.FromResult(new IndicatorConfigurationResultCompousedModel(
            new ActionIndicatorDetailDtoModel(id, name, unitMeasurement, priority, [.. Milestones], alias),
            new ActionIndicatorUpdateClippedRequestModel(id, name, unitMeasurement, priority, inMilestones, [], [])));
    }

    protected override Task<IndicatorConfigurationResultCompousedModel> PerformEditionAsync()
    {
        return Task.FromResult(new IndicatorConfigurationResultCompousedModel(
            new ActionIndicatorDetailDtoModel(Id!.Value, name, unitMeasurement, priority, [.. Milestones], alias),
            new ActionIndicatorUpdateClippedRequestModel(Id!.Value, name, unitMeasurement, priority, inMilestones, patchMilestones, outMilestones, alias)));
    }

    public Guid? Id { get; set; }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public string? Alias { get => alias; set => SetProperty(ref alias, value); }

    public UnitMeasurementBasicDtoModel UnitMeasurement { get => unitMeasurement; set => SetProperty(ref unitMeasurement, value); }

    public ObservableCollection<UnitMeasurementBasicDtoModel> AvailableUnitmMeasurements { get; private set; }

    public ObservableCollection<ActionIndicatorMilestoneDetailDtoModel> Milestones { get; init; } = [];

    public ICommand CreateMilestoneCommand { get; init; }

    public ICommand UpdateMilestoneCommand { get; init; }

    public ICommand DeleteMilestoneCommand { get; init; }

    public ICommand DetailMilestoneCommand { get; init; }

    private void MilestoneCreateSuccess_Callback(ActionIndicatorMilestoneDetailDtoModel model)
    {
        inMilestones.Add(new ActionIndicatorMilestoneCreateClippedRequestModel(model.Id, model.At, model.Amount, model.Description));

        // TODO Order list !!!
        Milestones.Add(model);

        hasChangesFlag = true;
    }

    private void MilestoneModifySuccess_Callback(ActionIndicatorMilestoneDetailDtoModel model)
    {
        bool handled = false;

        foreach (var item in inMilestones)
        {
            if (item.Id != model.Id) continue;

            inMilestones.Remove(item);

            inMilestones.Add(new ActionIndicatorMilestoneCreateClippedRequestModel(model.Id, model.At, model.Amount, model.Description));

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in patchMilestones)
            {
                if (item.Id != model.Id) continue;

                patchMilestones.Remove(item);

                patchMilestones.Add(new ActionIndicatorMilestoneUpdateClippedRequestModel(model.Id, model.At, model.Amount, model.Description));

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            patchMilestones.Add(new ActionIndicatorMilestoneUpdateClippedRequestModel(model.Id, model.At, model.Amount, model.Description));
        }

        var index = -1;

        // TODO Order list !!!
        foreach (var item in Milestones)
        {
            index++;

            if (item.Id != model.Id) continue;

            Milestones[index] = new ActionIndicatorMilestoneDetailDtoModel(model.Id, model.At, model.Amount, model.Description);

            break;
        }

        hasChangesFlag = true;
    }
}
