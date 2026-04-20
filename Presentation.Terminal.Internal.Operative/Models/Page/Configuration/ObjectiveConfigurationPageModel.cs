using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.Page.Configuration;

public sealed class ObjectiveConfigurationPageModel : AbstractConfigurationPageModel<ObjectiveDetailDtoModel, ObjectiveDetailDtoModel>
{
    public static string TitleValidableProperty => nameof(Title);
    public static string DescriptionValidableProperty => nameof(Description);

    private int index = 1;
    private string? title;
    private string? description;

    public ObjectiveConfigurationPageModel(ObjectiveDetailDtoModel? model, Action<ObjectiveDetailDtoModel> successActionCallback) : base(model, successActionCallback, new Validators.ObjectiveConfigurationValidator())
    {
        if (model is null) return;

        Id = model.Id;
        index = model.Index;
        title = model.Title;
        description = model.Description;
    }

    public Guid? Id { get; set; }

    public int Index { get => index; set => SetProperty(ref index, value); }

    public string? Title { get => title; set => SetProperty(ref title, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    public override IValidationContext? ValidationContext => new ValidationContext<ObjectiveConfigurationPageModel>(this);

    protected override Task<ObjectiveDetailDtoModel> PerformCreationAsync()
    {
        ObjectiveCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new ObjectiveCreateRequestModel
            (
                Index,
                Title!,
                [],
                [],
                [],
                Description
            ));
    }

    protected override Task<ObjectiveDetailDtoModel> PerformEditionAsync()
    {
        ObjectiveCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new ObjectiveUpdateRequestModel
            (
                Id!.Value,
                Index,
                Title!,
                [],
                [],
                [],
                Description
            ));
    }
}
