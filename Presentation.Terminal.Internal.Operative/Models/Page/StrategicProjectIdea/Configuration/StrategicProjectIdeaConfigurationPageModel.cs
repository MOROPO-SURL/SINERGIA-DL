using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProjectIdea.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProjectIdea.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.StrategicProjectIdea.Configuration;

public sealed class StrategicProjectIdeaConfigurationPageModel : AbstractConfigurationPageModel<StrategicProjectIdeaDetailDtoModel, StrategicProjectIdeaDetailDtoModel>
{
    public static string TitleValidableProperty => nameof(Title);
    public static string ProgramValidableProperty => nameof(Program);
    public static string DescriptionValidableProperty => nameof(Description);

    private string title = null!;
    private StrategicProgramBasicDtoModel program = null!;
    private string? description;
    private int priority = 1;

    public StrategicProjectIdeaConfigurationPageModel(StrategicProjectIdeaDetailDtoModel? model, StrategicProgramBasicDtoModel[] availablePrograms, Action<StrategicProjectIdeaDetailDtoModel> successActionCallback) : base(model, successActionCallback, new StrategicProjectIdeaConfigurationValidator())
    {
        AvailablePrograms = availablePrograms;

        if (model is null) return;

        Id = model.Id;
        title = model.Title;
        program = availablePrograms.First(item => item.Id == model.Program.Id);
        description = model.Description;
        priority = model.Priority;
    }

    public Guid Id { get; set; }

    public string Title { get => title; set => SetProperty(ref title, value); }

    public StrategicProgramBasicDtoModel Program { get => program; set => SetProperty(ref program, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    public StrategicProgramBasicDtoModel[] AvailablePrograms { get; private set; }

    protected override Task<StrategicProjectIdeaDetailDtoModel> PerformCreationAsync()
    {
        StrategicProjectIdeaCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new StrategicProjectIdeaCreateRequestModel
            (
                title,
                program.Id,
                priority,
                true,
                description
            ));
    }

    protected override Task<StrategicProjectIdeaDetailDtoModel> PerformEditionAsync()
    {
        StrategicProjectIdeaCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new StrategicProjectIdeaUpdateRequestModel
            (
                Id,
                title,
                program.Id,
                priority,
                true,
                description
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<StrategicProjectIdeaConfigurationPageModel>(this);
}