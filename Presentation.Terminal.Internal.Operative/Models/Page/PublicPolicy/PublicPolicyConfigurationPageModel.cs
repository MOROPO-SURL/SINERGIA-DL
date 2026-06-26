using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Enumerations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.PublicPolicy.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.PublicPolicy.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.PublicPolicy;

public sealed class PublicPolicyConfigurationPageModel : AbstractConfigurationPageModel<PublicPolicyDetailDtoModel, PublicPolicyDetailDtoModel>
{
    public static string TitleValidableProperty => nameof(Title);
    public static string DescriptionValidableProperty => nameof(Description);

    private string title = null!;
    private DateTime publishedAt = DateTime.Now;
    private PublicPolicyKind kind = PublicPolicyKind.Municipal;
    private string? description;

    public PublicPolicyConfigurationPageModel(PublicPolicyDetailDtoModel? model, Action<PublicPolicyDetailDtoModel> successCallbackAction) : base(model, successCallbackAction, new PublicPolicyConfigurationValidator())
    {
        if (model is null) return;

        Id = model.Id;
        title = model.Title;
        description = model.Description;
    }

    public Guid? Id { get; set; }

    public string Title { get => title; set => SetProperty(ref title, value); }

    public PublicPolicyKind Kind { get => kind; set => SetProperty(ref kind, value); }

    public DateTime PublishedAt { get => publishedAt; set => SetProperty(ref publishedAt, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    protected override Task<PublicPolicyDetailDtoModel> PerformCreationAsync()
    {
        PublicPolicyCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new PublicPolicyCreateRequestModel
            (
                Title!,
                Kind,
                PublishedAt,
                Description
            ));
    }

    protected override Task<PublicPolicyDetailDtoModel> PerformEditionAsync()
    {
        PublicPolicyCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new PublicPolicyUpdateRequestModel
            (
                Id!.Value,
                Title!,
                Kind,
                PublishedAt,
                Description
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<PublicPolicyConfigurationPageModel>(this);
}
