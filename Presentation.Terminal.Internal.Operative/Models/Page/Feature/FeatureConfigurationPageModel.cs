using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Feature.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Feature.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.FeatureKind.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;
using System.Collections.ObjectModel;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.Feature;

public sealed class FeatureConfigurationPageModel : AbstractConfigurationPageModel<FeatureDetailDtoModel, FeatureDetailDtoModel>
{
    public static string KindValidableProperty => nameof(Kind);
    public static string DescriptionValidableProperty => nameof(Description);

    private FeatureKindBasicDtoModel kind = null!;
    private string description = null!;

    public FeatureConfigurationPageModel(FeatureDetailDtoModel? model, Action<FeatureDetailDtoModel> successCallbackAction) : base(model, successCallbackAction, new FeatureConfigurationValidator())
    {
        if (model is null) return;

        Id = model.Id;
        kind = new FeatureKindBasicDtoModel(model.Kind.Id, model.Kind.Name);
        description = model.Description;
    }

    public Guid? Id { get; set; }

    public FeatureKindBasicDtoModel Kind { get => kind; set => SetProperty(ref kind, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public ObservableCollection<FeatureKindBasicDtoModel> AvailableKinds { get; set; } = [];

    protected override Task<FeatureDetailDtoModel> PerformCreationAsync()
    {
        FeatureCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new FeatureCreateRequestModel
            (
                Kind.Id,
                Description
            ));
    }

    protected override Task<FeatureDetailDtoModel> PerformEditionAsync()
    {
        FeatureCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new FeatureUpdateRequestModel
            (
                Id!.Value,
                Kind.Id,
                Description
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<FeatureConfigurationPageModel>(this);
}