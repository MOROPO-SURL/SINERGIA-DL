using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.UnitMeasurement.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Objective.Configuration;

public sealed class ObjectiveMilestoneConfigurationPageModel : AbstractConfigurationPageModel<ObjectiveActionIndicatorMilestoneDetailDtoModel, ObjectiveActionIndicatorMilestoneDetailDtoModel>
{
    public static string AmountValidableProperty => nameof(Amount);
    public static string DescriptionValidableProperty => nameof(Description);

    private DateTime at;
    private float amount;
    private string? description;

    public ObjectiveMilestoneConfigurationPageModel(ObjectiveActionIndicatorMilestoneDetailDtoModel? model, UnitMeasurementBasicDtoModel unitMeasurement, Action<ObjectiveActionIndicatorMilestoneDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
    {
        UnitMeasurement = unitMeasurement;

        Id = model?.Id;
        at = model?.At.ToDateTime(default) ?? DateTime.Now;
        amount = model?.Amount ?? 0f;
        description = model?.Description;
    }

    protected override bool PresentChangeNotification => false;

    public override IValidationContext? ValidationContext => new ValidationContext<ObjectiveMilestoneConfigurationPageModel>(this);

    protected override Task<ObjectiveActionIndicatorMilestoneDetailDtoModel> PerformCreationAsync()
    {
        return Task.FromResult(new ObjectiveActionIndicatorMilestoneDetailDtoModel(Guid.NewGuid(), DateOnly.FromDateTime(at), amount, description));
    }

    protected override Task<ObjectiveActionIndicatorMilestoneDetailDtoModel> PerformEditionAsync()
    {
        return Task.FromResult(new ObjectiveActionIndicatorMilestoneDetailDtoModel(Id!.Value, DateOnly.FromDateTime(at), amount, description));
    }

    public Guid? Id { get; set; }

    public UnitMeasurementBasicDtoModel UnitMeasurement { get; init; }

    public DateTime At { get => at; set => SetProperty(ref at, value); }

    public float Amount { get => amount; set => SetProperty(ref amount, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }
}
