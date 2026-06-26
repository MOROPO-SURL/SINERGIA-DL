using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Common.Configuration;

public sealed class WebSiteAddressConfigurationPageModel : AbstractConfigurationPageModel<WebSiteAddressDetailDtoModel, WebSiteAddressDetailDtoModel>
{
    public static string UrlValidableProperty => nameof(Url);
    public static string NameValidableProperty => nameof(Name);

    private string url = null!;
    private string name = null!;

    public WebSiteAddressConfigurationPageModel(WebSiteAddressDetailDtoModel? model, Action<WebSiteAddressDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
    {
        if (model == null) return;

        url = model.Url;
        name = model.Name;
    }

    public string Url { get => url; set => SetProperty(ref url, value); }

    public string Name { get => name; set => SetProperty(ref name, value); }

    protected override bool PresentChangeNotification => false;

    protected override Task<WebSiteAddressDetailDtoModel> PerformCreationAsync()
    {
        return Task.FromResult(new WebSiteAddressDetailDtoModel(Name, Url));
    }

    protected override Task<WebSiteAddressDetailDtoModel> PerformEditionAsync()
    {
        return Task.FromResult(new WebSiteAddressDetailDtoModel(Name, Url));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<WebSiteAddressConfigurationPageModel>(this);
}