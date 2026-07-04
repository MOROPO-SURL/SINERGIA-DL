using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.EconomicActivity.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.EconomicActivity.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.EconomicActivity;

public sealed class EconomicActivityConfigurationPageModel : AbstractConfigurationPageModel<EconomicActivityDetailDtoModel, EconomicActivityDetailDtoModel>
{
    public static string IdValidableProperty => nameof(Id);
    public static string NameValidableProperty => nameof(Name);

    private int id;
    private string name = null!;

    public EconomicActivityConfigurationPageModel(EconomicActivityDetailDtoModel? model, Action<EconomicActivityDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
    {
        if (model == null) return;

        id = model.Id;
        name = model.Name;
    }

    public int Id { get => id; set => SetProperty(ref id, value); }

    public string Name { get => name; set => SetProperty(ref name, value); }

    protected override Task<EconomicActivityDetailDtoModel> PerformCreationAsync()
    {
        EconomicActivityCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new EconomicActivityCreateRequestModel
            (
                Id,
                Name
            ));
    }

    protected override Task<EconomicActivityDetailDtoModel> PerformEditionAsync()
    {
        EconomicActivityCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new EconomicActivityUpdateRequestModel
            (
                Id, 
                Name
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<EconomicActivityConfigurationPageModel>(this);
}
