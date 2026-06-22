using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Validators;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProgram.Configuration;

public sealed class StrategicProgramConfigurationPageModel : AbstractConfigurationPageModel<StrategicProgramDetailDtoModel, StrategicProgramDetailDtoModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string LineValidableProperty => nameof(Line);
    public static string CoordinatorValidableProperty => nameof(Coordinator);
    public static string ObjectiveValidableProperty => nameof(Objective);
    public static string DescriptionValidableProperty => nameof(Description);

    private StrategicLineBasicDtoModel line = null!;
    private string name = null!;
    private PersonBasicDtoModel coordinator = null!;
    private string objective = null!;
    private string? description;
    private int priority = 1;

    public StrategicProgramConfigurationPageModel(StrategicProgramDetailDtoModel? model, StrategicLineBasicDtoModel[] availableLines, Action<StrategicProgramDetailDtoModel> successActionCallback) : base(model, successActionCallback, new StrategicProgramConfigurationValidator())
    {
        AvailableLines = availableLines;

        if (model is null) return;

        Id = model.Id;
        line = availableLines.First(item => item == model.Line);
        name = model.Name;
        objective = model.Objective;
        coordinator = model.Coordinator;
        description = model.Description;
        priority = model.Priority;
    }

    public Guid Id { get; set; }

    public StrategicLineBasicDtoModel Line { get => line; set => SetProperty(ref line, value); }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public PersonBasicDtoModel Coordinator { get => coordinator; set => SetProperty(ref coordinator, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public string Objective { get => objective; set => SetProperty(ref objective, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    public StrategicLineBasicDtoModel[] AvailableLines { get; private set; }

    protected override Task<StrategicProgramDetailDtoModel> PerformCreationAsync()
    {
        StrategicProgramCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new StrategicProgramCreateRequestModel
            (
                name,
                true,
                line.Id,
                coordinator.Id,
                objective,
                priority,
                description
            ));
    }

    protected override Task<StrategicProgramDetailDtoModel> PerformEditionAsync()
    {
        StrategicProgramCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new StrategicProgramUpdateRequestModel
            (
                Id,
                name,
                line.Id,
                coordinator.Id,
                objective,
                priority,
                true,
                description
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<StrategicProgramConfigurationPageModel>(this);
}