using FluentValidation;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Validators;

public class SettingValidator : AbstractValidator<Models.Page.SettingPageModel>
{
    public SettingValidator()
    {
        RuleFor(model => model.ProxyServerAddress).Must((model, value) =>
        {
            if (!model.UseProxyServer) return true;

            return !string.IsNullOrEmpty(value) && Uri.TryCreate(value, UriKind.Absolute, out Uri? uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps) && !uriResult.IsUnc;
        });

        RuleFor(model => model.ProxyUsername).Must((model, value) =>
        {
            if (!model.UseProxyAuthentication) return true;

            return !string.IsNullOrEmpty(value);
        });

        RuleFor(model => model.ProxyPassword).Must((model, value) =>
        {
            if (!model.UseProxyAuthentication) return true;

            return !string.IsNullOrEmpty(value);
        });
    }
}
