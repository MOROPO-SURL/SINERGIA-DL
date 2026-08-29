using FluentValidation;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration.Clipped;

public sealed class ImpactClippedConfigurationPageModel : AbstractConfigurationPageModel<ImpactDetailDtoModel, ImpactDetailDtoModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string DescriptionValidableProperty => nameof(Description);

    private string name = null!;
    private int priority = 1;
    private string? description;

    public ImpactClippedConfigurationPageModel(ImpactDetailDtoModel? model, Action<ImpactDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
    {
        if (model == null) return;

        Id = model.Id;
        name = model.Name;
        priority = model.Priority;
        description = model.Description;
    }

    public Guid? Id { get; set; }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    protected override bool PresentChangeNotification => false;

    protected override Task<ImpactDetailDtoModel> PerformCreationAsync()
    {
        return Task.FromResult(new ImpactDetailDtoModel(Guid.NewGuid(), name, priority, description));
    }

    protected override Task<ImpactDetailDtoModel> PerformEditionAsync()
    {
        return Task.FromResult(new ImpactDetailDtoModel(Id!.Value, name, priority, description));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<ImpactClippedConfigurationPageModel>(this);
}
