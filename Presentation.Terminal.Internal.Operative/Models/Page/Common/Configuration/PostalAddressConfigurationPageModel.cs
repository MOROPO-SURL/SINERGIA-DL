using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Common.Configuration;

public sealed class PostalAddressConfigurationPageModel : AbstractConfigurationPageModel<PostalAddressDetailDtoModel, PostalAddressDetailDtoModel>
{
    public static string StreetValidableProperty => nameof(Street);
    public static string NameValidableProperty => nameof(Name);

    private string street = null!;
    private string? number;
    private string? context;
    private int? zipCode;
    private string? name;

    public PostalAddressConfigurationPageModel(PostalAddressDetailDtoModel? model, Action<PostalAddressDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
    {
        if (model == null) return;

        street = model.Street;
        number = model.Number;
        zipCode = model.ZipCode;
        name = model.Name;
    }

    public string Street { get => street; set => SetProperty(ref street, value); }

    public string? Number { get => number; set => SetProperty(ref number, value); }

    public string? Context { get => context; set => SetProperty(ref context, value); }

    public int? ZipCode { get => zipCode; set => SetProperty(ref zipCode, value); }

    public string? Name { get => name; set => SetProperty(ref name, value); }

    protected override bool PresentChangeNotification => false;

    protected override Task<PostalAddressDetailDtoModel> PerformCreationAsync()
    {
        return Task.FromResult(new PostalAddressDetailDtoModel(Street, Number, Context, ZipCode, Name));
    }

    protected override Task<PostalAddressDetailDtoModel> PerformEditionAsync()
    {
        return Task.FromResult(new PostalAddressDetailDtoModel(Street, Number, Context, ZipCode, Name));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<PostalAddressConfigurationPageModel>(this);
}