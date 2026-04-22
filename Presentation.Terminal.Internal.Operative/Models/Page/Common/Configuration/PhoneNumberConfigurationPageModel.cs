using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Common.Configuration;

public sealed class PhoneNumberConfigurationPageModel : AbstractConfigurationPageModel<PhoneNumberDetailDtoModel, PhoneNumberDetailDtoModel>
{
    public static string ValueValidableProperty => nameof(Value);
    public static string NameValidableProperty => nameof(Name);

    private string _value = null!;
    private string? name;

    public PhoneNumberConfigurationPageModel(PhoneNumberDetailDtoModel? model, Action<PhoneNumberDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
    {
        if (model == null) return;

        _value = model.Value;
        name = model.Name;
    }

    public string Value { get => _value; set => SetProperty(ref _value, value); }

    public string? Name { get => name; set => SetProperty(ref name, value); }

    protected override Task<PhoneNumberDetailDtoModel> PerformCreationAsync()
    {
        return Task.FromResult(new PhoneNumberDetailDtoModel(Value, Name));
    }

    protected override Task<PhoneNumberDetailDtoModel> PerformEditionAsync()
    {
        return Task.FromResult(new PhoneNumberDetailDtoModel(Value, Name));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<PhoneNumberConfigurationPageModel>(this);
}
