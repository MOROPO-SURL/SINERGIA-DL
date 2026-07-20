using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.UnitMeasurement.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration.Clipped;

public sealed class MilestoneClippedConfigurationPageModel : AbstractConfigurationPageModel<ActionIndicatorMilestoneDetailDtoModel, ActionIndicatorMilestoneDetailDtoModel>
{
    public static string AmountValidableProperty => nameof(Amount);
    public static string DescriptionValidableProperty => nameof(Description);

    private DateTime at;
    private float amount;
    private string? description;

    public MilestoneClippedConfigurationPageModel(ActionIndicatorMilestoneDetailDtoModel? model, UnitMeasurementBasicDtoModel unitMeasurement, Action<ActionIndicatorMilestoneDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
    {
        UnitMeasurement = unitMeasurement;

        Id = model?.Id;
        at = model?.At.ToDateTime(default) ?? DateTime.Now;
        amount = model?.Amount ?? 0f;
        description = model?.Description;
    }

    protected override bool PresentChangeNotification => false;

    public override IValidationContext? ValidationContext => new ValidationContext<MilestoneClippedConfigurationPageModel>(this);

    protected override Task<ActionIndicatorMilestoneDetailDtoModel> PerformCreationAsync()
    {
        return Task.FromResult(new ActionIndicatorMilestoneDetailDtoModel(Guid.NewGuid(), DateOnly.FromDateTime(at), amount, description));
    }

    protected override Task<ActionIndicatorMilestoneDetailDtoModel> PerformEditionAsync()
    {
        return Task.FromResult(new ActionIndicatorMilestoneDetailDtoModel(Id!.Value, DateOnly.FromDateTime(at), amount, description));
    }

    public Guid? Id { get; set; }

    public UnitMeasurementBasicDtoModel UnitMeasurement { get; init; }

    public DateTime At { get => at; set => SetProperty(ref at, value); }

    public float Amount { get => amount; set => SetProperty(ref amount, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }
}
