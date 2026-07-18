using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.UnitMeasurement.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using System.Collections.ObjectModel;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration.Clipped;

public sealed class IndicatorClippedConfigurationPageModel : AbstractConfigurationPageModel<ActionIndicatorDetailDtoModel, ActionIndicatorDetailDtoModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string AliasValidableProperty => nameof(Alias);
    public static string UnitMeasurementValidableProperty => nameof(UnitMeasurement);

    private string name = null!;
    private int priority = 1;
    private string? alias;
    private UnitMeasurementBasicDtoModel unitMeasurement = null!;

    protected override bool PresentChangeNotification => false;

    public override IValidationContext? ValidationContext => new ValidationContext<IndicatorClippedConfigurationPageModel>(this);

    public IndicatorClippedConfigurationPageModel(ActionIndicatorDetailDtoModel? model, IEnumerable<UnitMeasurementBasicDtoModel> availableUnitmMeasurements, Action<ActionIndicatorDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
    {
        AvailableUnitmMeasurements = [.. availableUnitmMeasurements];

        if (model == null) return;

        Id = model.Id;
        name = model.Name;
        alias = model.Alias;
        unitMeasurement = AvailableUnitmMeasurements.First(item =>  item.Id == model.UnitMeasurement.Id);
    }

    protected override Task<ActionIndicatorDetailDtoModel> PerformCreationAsync()
    {
        return Task.FromResult(new ActionIndicatorDetailDtoModel(Guid.NewGuid(), name, unitMeasurement!, alias));
    }

    protected override Task<ActionIndicatorDetailDtoModel> PerformEditionAsync()
    {
        return Task.FromResult(new ActionIndicatorDetailDtoModel(Id!.Value, name, unitMeasurement, alias));
    }

    public Guid? Id { get; set; }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public string? Alias { get => alias; set => SetProperty(ref alias, value); }

    public UnitMeasurementBasicDtoModel UnitMeasurement { get => unitMeasurement; set => SetProperty(ref unitMeasurement, value); }

    public ObservableCollection<UnitMeasurementBasicDtoModel> AvailableUnitmMeasurements { get; private set; }
}
