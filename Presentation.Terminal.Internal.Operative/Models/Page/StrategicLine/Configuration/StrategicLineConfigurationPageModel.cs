using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Validators;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicLine.Configuration;

public sealed class StrategicLineConfigurationPageModel : AbstractConfigurationPageModel<StrategicLineDetailDtoModel, StrategicLineDetailDtoModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string AxeValidableProperty => nameof(Axe);
    public static string CoordinatorValidableProperty => nameof(Coordinator);
    public static string DescriptionValidableProperty => nameof(Description);

    private int id = 1;
    private StrategicAxeBasicDtoModel axe = null!;
    private string name = null!;
    private PersonBasicDtoModel coordinator = null!;
    private string? description;

    public StrategicLineConfigurationPageModel(StrategicLineDetailDtoModel? model, StrategicAxeBasicDtoModel[] availableAxes, Action<StrategicLineDetailDtoModel> successActionCallback) : base(model, successActionCallback, new StrategicLineConfigurationValidator())
    {
        AvailableAxes = availableAxes;

        if (model is null) return;

        Id = model.Id;
        axe = availableAxes.First(item => item == model.StrategicAxe);
        name = model.Name;
        coordinator = model.Coordinator;
        description = model.Description;
    }

    public int Id { get => id; set => SetProperty(ref id, value); }

    public StrategicAxeBasicDtoModel Axe { get => axe; set => SetProperty(ref axe, value); }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public PersonBasicDtoModel Coordinator { get => coordinator; set => SetProperty(ref coordinator, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    public StrategicAxeBasicDtoModel[] AvailableAxes { get; private set; }

    protected override Task<StrategicLineDetailDtoModel> PerformCreationAsync()
    {
        StrategicLineCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new StrategicLineCreateRequestModel
            (
                Id,
                axe.Id,
                true,
                Name,
                Coordinator.Id,
                Description
            ));
    }

    protected override Task<StrategicLineDetailDtoModel> PerformEditionAsync()
    {
        StrategicLineCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new StrategicLineUpdateRequestModel
            (
                Id!,
                axe.Id,
                true,
                Name,
                Coordinator.Id,
                Description
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<StrategicLineConfigurationPageModel>(this);
}