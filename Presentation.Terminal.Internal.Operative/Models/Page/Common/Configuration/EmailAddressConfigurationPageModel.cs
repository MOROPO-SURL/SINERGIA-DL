using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Common.Configuration;

public class EmailAddressConfigurationPageModel : AbstractConfigurationPageModel<EmailAddressDetailDtoModel, EmailAddressDetailDtoModel>
{
    public static string ValueValidableProperty => nameof(Value);
    public static string NameValidableProperty => nameof(Name);

    private string _value = null!;
    private string? name;

    public EmailAddressConfigurationPageModel(EmailAddressDetailDtoModel? model, Action<EmailAddressDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
    {
        if (model == null) return;

        _value = model.Value;
        name = model.Name;
    }

    public string Value { get => _value; set => SetProperty(ref _value, value); }

    public string? Name { get => name; set => SetProperty(ref name, value); }

    protected override bool PresentChangeNotification => false;

    protected override Task<EmailAddressDetailDtoModel> PerformCreationAsync()
    {
        return Task.FromResult(new EmailAddressDetailDtoModel(Value, Name));
    }

    protected override Task<EmailAddressDetailDtoModel> PerformEditionAsync()
    {
        return Task.FromResult(new EmailAddressDetailDtoModel(Value, Name));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<EmailAddressConfigurationPageModel>(this);
}