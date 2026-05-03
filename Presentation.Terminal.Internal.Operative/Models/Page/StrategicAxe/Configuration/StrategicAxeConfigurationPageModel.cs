using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Validators;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicAxe.Configuration;

public sealed class StrategicAxeConfigurationPageModel : AbstractConfigurationPageModel<StrategicAxeDetailDtoModel, StrategicAxeDetailDtoModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string DescriptionValidableProperty => nameof(Description);

    private int id = 1;
    private string? name;
    private string? description;

    public StrategicAxeConfigurationPageModel(StrategicAxeDetailDtoModel? model, Action<StrategicAxeDetailDtoModel> successActionCallback) : base(model, successActionCallback, new StrategicAxeConfigurationValidator())
    {
        if (model is null) return;

        Id = model.Id;
        name = model.Name;
        description = model.Description;
    }

    public int Id { get => id; set => SetProperty(ref id, value); }

    public string? Name { get => name; set => SetProperty(ref name, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    protected override Task<StrategicAxeDetailDtoModel> PerformCreationAsync()
    {
        StrategicAxeCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new StrategicAxeCreateRequestModel
            (
                Id,
                true,
                Name!,
                Description
            ));
    }

    protected override Task<StrategicAxeDetailDtoModel> PerformEditionAsync()
    {
        StrategicAxeCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new StrategicAxeUpdateRequestModel
            (
                Id!,
                true,
                Name!,
                Description
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<StrategicAxeConfigurationPageModel>(this);
}