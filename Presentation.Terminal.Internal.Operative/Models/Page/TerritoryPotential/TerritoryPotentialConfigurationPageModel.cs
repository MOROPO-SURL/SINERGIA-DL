using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Internal.Operative.Clients;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritoryPotential.CQRS.Command;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritoryPotential.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Validators;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Models.Page.TerritoryPotential;

public sealed class TerritoryPotentialConfigurationPageModel : AbstractConfigurationPageModel<TerritoryPotentialDetailDtoModel, TerritoryPotentialDetailDtoModel>
{
    public static string TitleValidableProperty => nameof(Title);
    public static string DescriptionValidableProperty => nameof(Description);

    private string title = null!;
    private string? description;

    public TerritoryPotentialConfigurationPageModel(TerritoryPotentialDetailDtoModel? model, Action<TerritoryPotentialDetailDtoModel> successCallbackAction) : base(model, successCallbackAction, new TerritoryPotentialConfigurationValidator())
    {
        if (model is null) return;

        Id = model.Id;
        title = model.Title;
        description = model.Description;
    }

    public Guid? Id { get; set; }

    public string Title { get => title; set => SetProperty(ref title, value); }

    public string? Description { get => description; set => SetProperty(ref description, value); }

    protected override Task<TerritoryPotentialDetailDtoModel> PerformCreationAsync()
    {
        TerritoryPotentialCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.CreateAsync(new TerritoryPotentialCreateRequestModel
            (
                Title!,
                Description
            ));
    }

    protected override Task<TerritoryPotentialDetailDtoModel> PerformEditionAsync()
    {
        TerritoryPotentialCommandApiClient apiClient = new(IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>());

        return apiClient.UpdateAsync(new TerritoryPotentialUpdateRequestModel
            (
                Id!.Value,
                Title!,
                Description
            ));
    }

    public override IValidationContext? ValidationContext => new ValidationContext<TerritoryPotentialConfigurationPageModel>(this);
}
