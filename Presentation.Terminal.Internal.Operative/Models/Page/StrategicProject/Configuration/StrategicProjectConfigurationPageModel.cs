using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProjectKind.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Validators;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProject.Configuration;

public sealed class StrategicProjectConfigurationPageModel : AbstractConfigurationPageModel<StrategicProjectDetailDtoModel, StrategicProjectDetailDtoModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string KindValidableProperty => nameof(Kind);
    public static string ProgramValidableProperty => nameof(Program);
    public static string DescriptionValidableProperty => nameof(Description);

    private string name = null!;
    private StrategicProjectKindBasicDtoModel kind = null!;
    private StrategicProgramBasicDtoModel program = null!;
    private string? description;
    private int priority = 1;

    public StrategicProjectConfigurationPageModel(StrategicProjectDetailDtoModel? model, StrategicProjectKindBasicDtoModel[] availableKinds, StrategicProgramBasicDtoModel[] availablePrograms, Action<StrategicProjectDetailDtoModel> successActionCallback) : base(model, successActionCallback, new StrategicProjectConfigurationValidator())
    {
        AvailableKinds = availableKinds;
        AvailablePrograms = availablePrograms;

        if (model is null) return;

        Id = model.Id;
        name = model.Name;
        kind = availableKinds.First(item => item == model.Kind);
        program = availablePrograms.First(item => item.Id == model.Program.Id);
        description = model.Description;
        priority = model.Priority;
    }

    public Guid Id { get; set; }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public StrategicProjectKindBasicDtoModel Kind { get => kind; set => SetProperty(ref kind, value); }

    public StrategicProgramBasicDtoModel Program { get => program; set => SetProperty(ref program, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    public StrategicProjectKindBasicDtoModel[] AvailableKinds { get; private set; }

    public StrategicProgramBasicDtoModel[] AvailablePrograms { get; private set; }

    protected override Task<StrategicProjectDetailDtoModel> PerformCreationAsync()
    {
        StrategicProjectCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new StrategicProjectCreateRequestModel
            (
                name,
                kind.Id,
                program.Id,
                priority,
                true,
                description
            ));
    }

    protected override Task<StrategicProjectDetailDtoModel> PerformEditionAsync()
    {
        StrategicProjectCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new StrategicProjectUpdateRequestModel
            (
                Id,
                name,
                kind.Id,
                program.Id,
                priority,
                true,
                description
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<StrategicProjectConfigurationPageModel>(this);
}